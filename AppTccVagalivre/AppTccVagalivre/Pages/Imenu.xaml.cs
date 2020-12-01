using AppTccVagalivre.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using Plugin.Geolocator.Abstractions;
using System.Collections.ObjectModel;
using Xamarin.Forms.Maps;
using System.Net.Http;

namespace AppTccVagalivre.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Imenu : ContentPage
    {



        private User user;
        public ObservableCollection<Pin> Pins { get; set; }

        public Imenu()
        {




        }




        public Imenu(User user)
        {
            InitializeComponent();

            this.Padding = Device.OnPlatform(new
   Thickness(10, 20, 10, 10),
   new Thickness(10),
   new Thickness(10)
    );

            Pins = new ObservableCollection<Pin>();


            this.user = user;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            usernameLabel.Text = this.user.Nome;
            photoImage.Source = this.user.PhotoFullpath;
            photoImage.WidthRequest = 250;
            photoImage.HeightRequest = 250;

            buscarestacionamento.Clicked += Buscarestacionamento_Clicked;

        }

        private async void Buscarestacionamento_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cidadeentry.Text))
            {

                await DisplayAlert("Erro", "Digite um nome de cidade", "Aceitar");
                cidadeentry.Focus();
                return;
            }

            ConsultaMapalocalizacao();


        }


        private async void ConsultaMapalocalizacao()
        {


            WaitActivityIndicator.IsRunning = true;

            var localizacaoRequest = new LocalizacaoRequest
            {
                cidade = cidadeentry.Text,
                uf = ufentry.Text,
            };

            var jsonRequest = JsonConvert.SerializeObject(localizacaoRequest);
            var httpContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            var resp = string.Empty;

            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("http://www.appestapiloto.somee.com");
                var Url = "/api/Empresas/Pesquisavaga";
                var result = await client.PostAsync(Url, httpContent);
                await DisplayAlert("Error", client.BaseAddress + Url, "Aceitar 95");

                await DisplayAlert("Error", result.Content.ToString(), "Aceitar 95");

                if (!result.IsSuccessStatusCode)

                {
                    WaitActivityIndicator.IsRunning = false;
                    await DisplayAlert("Error", result.ToString(), "Aceitar");
                    WaitActivityIndicator.IsRunning = false;
                    return;
                }

                resp = await result.Content.ReadAsStringAsync();

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Aceitar 95");
                WaitActivityIndicator.IsRunning = false;
                return;

            }

            try
            {
                var empresas = JsonConvert.DeserializeObject<List<Empresa>>(resp);
                // empresa.RazaoSocial = ufentry.Text;
                // WaitActivityIndicator.IsRunning = false;



                  await DisplayAlert("Bem Vindo", user.Nome, "aceita");
                //  await DisplayAlert("Empresa Encontrada", empresa.NomeFantasia, "aceita");
                //  await DisplayAlert("Latitude", empresa.Latitude, "aceita");
               //  await DisplayAlert("Longetude", empresa.Longitude, "aceita");
            await Navigation.PushAsync(new ConsultaMapa(empresas));


            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Desseralizar");
            }


        }
    }




    }

   







