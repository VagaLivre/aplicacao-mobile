using AppTccVagalivre.Classes;
using AppTccVagalivre.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace AppTccVagalivre.Classes
{
    public class Geololizacao : INotifyPropertyChanged
    {

        private User user;
        public ObservableCollection<Pin> Pins { get; set; }




        public void GetGeolocation()
        {

            /*Mapa.MoveToRegion(MapSpan.FromCenterAndRadius(
                             new Position(–23.4859591, –47.4420192),
                             Distance.FromMiles(0.5)));
            try { 
            var position1 = new Position(-23.536937, -46.779427);
            var pin1 = new Pin

            {
                Type = PinType.Place,
                Position = position1,
                Label = "Demo Maps",
                Address = "http://www.julianocustodio.com",
            };

            Pins.Add(pin1);
        }catch (Exception ex)*/
        {




        }

}


/*
try
{
    var position1 = new Position(-23.536937, -46.779427);
    var pin1 = new Pin
    { 
        Type = PinType.Place,
        Position = position1,
        Label = "Pin1",
        Id=1,
        Address = "Local Pino 01"
    };


    var position2 = new Position(-18.753730, -44.430406);
    var pin2 = new Pin
    {

        Type = PinType.Place,
        Position = position2,
        Label = "Pin2",
        Id = 2,
        Address = "Local Pino 02"
    };
    Pins.Add(pin2);

    var position3 = new Position(-12.971687, -38.475612);
    var pin3 = new Pin
    {
        Type = PinType.Place,
        Position = position3,
        Label = "Pin3",
        Id = 3,
        Address = "Local Pino 03"
    };
    Pins.Add(pin3);

*/




internal void GetGeolocation(string name, string address, double latitude, double longitude)
        {
            var position = new Position(latitude, longitude);
            var pin = new Pin
            {
                Type = PinType.Place,
                Position = position,
                Label = name,
                Address = address
            };
            Pins.Add(pin);


        }

        private static Geololizacao instance;

        public static Geololizacao GetInstancee()
        {
            if (instance == null)
            {
                instance = new Geololizacao();
            }

            return instance;
        }




        public event PropertyChangedEventHandler PropertyChanged;

      





    }

}

   
