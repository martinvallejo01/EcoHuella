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
		public Home ()
		{
            InitializeComponent();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            Models.Home home = new Models.Home
            {
                Size = Double.Parse(size.Text),
                Energy = Double.Parse(energy.Text),
                Population = int.Parse(population.Text)
            };

            DisplayAlert("Your Home FootPrint is:", home.FootPrint().ToString(), "OK");
                
        }
    }
}