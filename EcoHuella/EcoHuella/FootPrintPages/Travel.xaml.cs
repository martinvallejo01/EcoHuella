using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EcoHuella.Models;

namespace EcoHuella.FootPrintPages
{

	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Travel : ContentPage
	{
        double[] EngineFactor = { 0.64, 0.81, 0.104 };
        double[] GasFactor = { 2900, 2038 };
        double[] PeopleInCarFactor = { 0.25, 0.5, 0.75, 1 };

        EcoFootPrint FootPrint;
        public Travel (EcoFootPrint ecoFootPrint)
		{
            FootPrint = ecoFootPrint;
			InitializeComponent ();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            bool planeAproved, busAproved, carAproved;

            planeAproved = int.TryParse(hoursInPlane.Text, out int plane);
            busAproved = int.TryParse(hoursInbus.Text, out int bus);
            carAproved = int.TryParse(kilometerIncar.Text, out int car);

            if (!planeAproved || !busAproved || !carAproved)
            {
                await DisplayAlert("Error", "Check you inputs, something went terribly wrong", "OK");
            }

            double engineMult = EngineFactor[engine.SelectedIndex];
            double gasMult = GasFactor[gasoline.SelectedIndex];
            double peopleMult = PeopleInCarFactor[people.SelectedIndex];

            FootPrint.AirPlane = plane;
            FootPrint.Bus = bus;
            FootPrint.CarKm = car;
            FootPrint.CarEngine = engineMult;
            FootPrint.CarGas = gasMult;
            FootPrint.CarPeople = peopleMult;

            Double footprint = FootPrint.TravelFootPrint();
            App.DbContext.Update(FootPrint);
            await DisplayAlert("Your Travel FootPrint is", footprint.ToString(), "OK");
            await App.DbContext.SaveChangesAsync();

        }
    }
}