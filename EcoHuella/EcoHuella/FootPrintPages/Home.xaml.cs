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
	public partial class Home : ContentPage
	{
        EcoFootPrint FootPrint;
		public Home (EcoFootPrint ecoFootPrint)
		{
            FootPrint = ecoFootPrint;
            InitializeComponent();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {

            FootPrint.Size = Double.Parse(size.Text);
            FootPrint.Energy = Double.Parse(energy.Text);
            FootPrint.Population = int.Parse(population.Text);

            await DisplayAlert("Your Home FootPrint is:", FootPrint.HomeFootPrint().ToString(), "OK");
            App.DbContext.Update(FootPrint);
            await App.DbContext.SaveChangesAsync();
        }
    }
}