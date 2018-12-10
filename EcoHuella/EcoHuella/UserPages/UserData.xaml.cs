using EcoHuella.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EcoHuella;
using EcoHuella.FootPrintPages;
using Microsoft.EntityFrameworkCore;

namespace EcoHuella.UserPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserData : ContentPage
	{
		public UserData ()
		{
			InitializeComponent ();
		}

        protected async override void OnAppearing()
        {
            userList.ItemsSource = await App.DbContext.User.ToListAsync();
            base.OnAppearing();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            User user = new User
            {
                UserID = int.Parse(idEntry.Text),
                Name = nameEntry.Text,
                Mail = mailEntry.Text
            };

            await App.DbContext.AddAsync(user);
            EcoFootPrint ecoFoot = new EcoFootPrint();
            ecoFoot.MeasureDate = DateTime.Today;
            await App.DbContext.AddAsync(ecoFoot);
            ecoFoot.User = user;
            await App.DbContext.SaveChangesAsync();
            await Navigation.PushAsync(new FootPrint(user, ecoFoot));
        }

        private async void UserList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var user = e.SelectedItem as User;
            if (user == null) { return; }
            await Navigation.PushAsync(new Page1(user.UserID));
            userList.SelectedItem = null;
        }
    }
}