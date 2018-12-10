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
        public User User;
        public EcoFootPrint EcoFoot;

        public Double food, travel, home;

		public FootPrint (User user, EcoFootPrint pEcoFoot)
		{
            User = user;
            EcoFoot = pEcoFoot;
			InitializeComponent ();
		}

        protected async override void OnAppearing()
        {
            food = 0;
            travel = 0;
            home = 0;

            await App.DbContext.SaveChangesAsync();
            try { food = EcoFoot.FoodFootPrint(); }
            catch (Exception e) { food = 0; }

            try { travel = EcoFoot.TravelFootPrint(); }
            catch (Exception e) { travel = 0; }

            try { home = EcoFoot.HomeFootPrint(); }
            catch (Exception e) { home = 0; }

            try { if (food != 0) { FoodFoot.Text = food.ToString(); } }
            catch (Exception e) { }

            try { if (home != 0) { HomeFoot.Text = home.ToString(); } }
            catch (Exception e) { }

            try { if (travel != 0) { TravelFoot.Text = travel.ToString(); } }
            catch (Exception e) { }

            try
            {
                Double footprint = food + travel + home;
                footPrintLabel.Text = $"Your Total Foot Print is: {footprint}";
            } catch (Exception e) { }

            base.OnAppearing();
        }

        private async void FoodCell_Tapped(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new Food(EcoFoot));
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await App.DbContext.SaveChangesAsync();
            await Navigation.PopAsync();
        }

        private async void TravelCell_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Travel(EcoFoot));
        }

        private async void HomeCell_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Home(EcoFoot));
        }
    }
}