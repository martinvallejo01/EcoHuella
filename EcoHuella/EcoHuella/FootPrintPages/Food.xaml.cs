using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EcoHuella.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EcoHuella.FootPrintPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Food : ContentPage
	{
        int[] fruitData = { 0, 2, 4, 6, 9 };
        int[] vegiesData = { 0, 1, 2, 4, 6 };
        int[] breadData = { 27, 55, 93, 131, 170 };
        int[] dairyData = { 117, 274, 429, 585, 743 };
        int[] beerData = { 40, 79, 131, 186, 239 };
        int[] cowData = { 57, 121, 190, 267, 343 };
        int[] pigData = { 12, 25, 41, 140, 155 };
        int[] chickenData = { 234, 470, 789, 1107, 1410 };
        int[] fishData = { 217, 425, 711, 998, 1298 };
        int[] cigarretesData = { 3, 10, 24, 37, 52 };

        EcoFootPrint FootPrint { get; set; }
        public Food (EcoFootPrint ecoFootPrintID)
		{
            FootPrint = ecoFootPrintID;
			InitializeComponent ();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            FootPrint.Fruit = fruitData[fruits.SelectedIndex];
            FootPrint.Vegetable = vegiesData[vegies.SelectedIndex];
            FootPrint.Bread = breadData[bread.SelectedIndex];
            FootPrint.Dairy = dairyData[dairy.SelectedIndex];
            FootPrint.Beer = beerData[beer.SelectedIndex];
            FootPrint.Cow = cowData[cow.SelectedIndex];
            FootPrint.Pig = pigData[pig.SelectedIndex];
            FootPrint.Chicken = chickenData[chicken.SelectedIndex];
            FootPrint.Fish = fishData[fish.SelectedIndex];
            FootPrint.Cigarretes = cigarretesData[cigarretes.SelectedIndex];

            App.DbContext.Update(FootPrint);
            await DisplayAlert("Your food footPrint is", FootPrint.FoodFootPrint().ToString() , "OK");
            await Navigation.PopAsync();
        }
    }
}