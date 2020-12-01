using AppTccVagalivre.Classes;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace AppTccVagalivre.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaMapa : ContentPage
    {





        public ConsultaMapa(List<Empresa>  empresas)
        {

            InitializeComponent();


            // esse metodo e usado para passar a localização para ponto que vai abrir o mapa
            // var latitudec = Convert.ToDouble(empresa.Latitude, new CultureInfo("en-US"));
            //var longetudec = Convert.ToDouble(empresa.Longitude, new CultureInfo("en-US"));

            // Pegando fixo a localização
             var latitudec = Convert.ToDouble(-50.2993222, new CultureInfo("en-US"));
            var longetudec = Convert.ToDouble(-27.7904251, new CultureInfo("en-US"));

            try
            {


                var position2 = new Position(-50.2993222, -27.7904251);
            Mapa.MoveToRegion(MapSpan.FromCenterAndRadius(
                            new Position(position2.Latitude, position2.Longitude),
                            Distance.FromMiles(0.5)));


            //  var position1 = new Position(-27.7917169,-50.2996902);

           // var position1 = new Position(latitudec, longetudec);
            foreach (var empresa in empresas)
            {
               
                    var pin = new Pin
                    {
                        Type = PinType.Place,
                        Position = new Position(Convert.ToDouble(empresa.Latitude, new CultureInfo("en-US")), Convert.ToDouble(empresa.Longitude, new CultureInfo("en-US"))),
                        Label = "Nome Estacionamento..: " + empresa.NomeFantasia,
                        BindingContext = "Quantidade Vagas..: " + empresa.NDispo,
                        Address = "Endereco " + empresa.Endereco,
                    };

                    Mapa.Pins.Add(pin);



                }
                Console.ReadKey();

            }
            

              catch (Exception ex)
            {
                Debug.WriteLine("Unable to get location, may need to increase timeout: " + ex);
            }




        }

        private async void Locator()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;

            var location = await locator.GetPositionAsync(timeoutMilliseconds: 10000);
            var position = new Position(location.Latitude, location.Longitude);
            Mapa.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(.3)));
        }







    }
}
