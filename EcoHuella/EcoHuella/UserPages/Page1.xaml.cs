using EcoHuella.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EcoHuella.UserPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
        int ID;
		public Page1 (int userID)
		{
            ID = userID;
			InitializeComponent ();
		}

        protected async override void OnAppearing()
        {
            var list = await App.DbContext.EcoFootPrint.ToListAsync();
            var quearry = list.Where(x => x.UserID == ID);
            huellasList.ItemsSource = quearry;
            base.OnAppearing();
        }
    }
}