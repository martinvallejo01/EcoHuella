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
	public partial class FootPrint : ContentPage
	{
        public EcoFootPrint EcoFoot;
        double print = 0;
		public FootPrint ()
		{
            EcoFoot = new EcoFootPrint();
			InitializeComponent ();
		}

        private async void FoodCell_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Food(EcoFoot));
            print += EcoFoot.Food.CalculateFootPrint();
            FoodFoot.Text = EcoFoot.Food.CalculateFootPrint().ToString();
        }

        private async void TravelCell_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Travel(EcoFoot));
            print += EcoFoot.Travel.CalculateFootPrint();
            TravelFoot.Text = EcoFoot.Travel.CalculateFootPrint().ToString();
        }

        private async void HomeCell_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Home(EcoFoot));
            print += EcoFoot.Travel.CalculateFootPrint();
            HomeFoot.Text = EcoFoot.Home.CalculateFootPrint().ToString();
        }
    }
}