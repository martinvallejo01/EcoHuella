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


        public Food ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            Models.Food food = new Models.Food
            {
                Fruit = fruitData[fruits.SelectedIndex],
                Vegetable = vegiesData[vegies.SelectedIndex],
                Bread = breadData[bread.SelectedIndex],
                Dairy = dairyData[dairy.SelectedIndex],
                Beer = beerData[beer.SelectedIndex],
                Cow = cowData[cow.SelectedIndex],
                Pig = pigData[pig.SelectedIndex],
                Chicken = chickenData[chicken.SelectedIndex],
                Fish = fishData[fish.SelectedIndex],
                Cigarretes = cigarretesData[cigarretes.SelectedIndex]
            };

            DisplayAlert("Your food footPrint is", food.CalculateFootPrint().ToString() , "OK");
        }
    }
}