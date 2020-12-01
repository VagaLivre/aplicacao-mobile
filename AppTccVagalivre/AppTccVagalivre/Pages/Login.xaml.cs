using AppTccVagalivre.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;

namespace AppTccVagalivre.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
		public Login ()
		{
			InitializeComponent ();
            this.Padding = Device.OnPlatform(new
             Thickness(10, 20, 10, 10),
             new Thickness(10),
             new Thickness(10)
              );

            loginButton.Clicked += LoginButton_Clicked;


        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Emailentry.Text))
            {

                await DisplayAlert("Erro", "Digite um Email Valido linha 38", "Aceitar");
                Emailentry.Focus();
                return;
            }

            if (!Utilitario.isvalidEmail(Emailentry.Text) == false)
            {

                await DisplayAlert("Erro", "Digite um Email Valido linha 47", "Aceitar");
                Emailentry.Focus();
                return;
            }
            if (string.IsNullOrEmpty(passwordEntry.Text))
            {

                await DisplayAlert("Erro", "Digite um Senha Valido", "Aceitar");
                passwordEntry.Focus();
                return;

            }

            /* */

            this.Logar();
        }

        private async void Logar()
        {
            WaitActivityIndicator.IsRunning = true;
            var loginRequest = new LoginRequest
            {
                Email = Emailentry.Text,
                Senha = passwordEntry.Text,
            };

            var jsonRequest = JsonConvert.SerializeObject(loginRequest);
            var httpContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            var resp = string.Empty;

            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("http://www.appestapiloto.somee.com");
               var Url = "/api/Usuarios/Login";
                

                var result = await client.PostAsync(Url, httpContent);

                await DisplayAlert("Error", client.BaseAddress + Url, "Aceitar 95");

                await DisplayAlert("Error", result.ToString(), "Aceitar 95");

                if (!result.IsSuccessStatusCode)

                {
                    await DisplayAlert("Error", "Usuario ou Senha incorretos 89", "Aceitar");
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

            var user = JsonConvert.DeserializeObject<User>(resp);
            user.Password = passwordEntry.Text;
            WaitActivityIndicator.IsRunning = false;

            await DisplayAlert("Bem Vindo", user.Nome, "aceita");
            await Navigation.PushAsync(new Imenu(user));

        }
    }
}