using System;
using System.Collections.Generic;
using System.Text;

namespace EcoHuella.Models
{
    public class EcoFootPrint
    {

        public int FootPrintID { get; set; }
        public DateTime MeasureDate { get; set; }

        public int Bus { get; set; }
        public int AirPlane { get; set; }
        public int CarKm { get; set; }
        public double CarEngine { get; set; }
        public double CarGas { get; set; }
        public double CarPeople { get; set; }

        public int Fruit { get; set; }
        public int Vegetable { get; set; }
        public int Bread { get; set; }
        public int Cow { get; set; }
        public int Pig { get; set; }
        public int Chicken { get; set; }
        public int Fish { get; set; }
        public int Dairy { get; set; }
        public int Cigarretes { get; set; }
        public int Beer { get; set; }

        public Double Energy { get; set; }
        public Double Size { get; set; }
        public int Population { get; set; }

        public User User { get; set; }
        public int UserID { get; set; }

        public Double TravelFootPrint()
        {
            Double footPrint = CarKm * CarPeople * CarEngine * CarGas;
            footPrint /= 6.75;
            footPrint += AirPlane * 500;
            footPrint += Bus * 40;
            return footPrint / 10000;
        }

        public Double FoodFootPrint()
        {
            Double r = Fruit;
            r += Vegetable;
            r += Bread;
            r += Cow;
            r += Pig;
            r += Chicken;
            r += Fish;
            r += Dairy;
            r += Cigarretes;
            r += Beer;

            return r / 10000;
        }

        public Double HomeFootPrint()
        {
            Double r = Energy * 0.045 / 1000;
            r += Size * 0.103716 / 50;
            r /= Population;
            return r;
        }

        public Double FootPrint()
        {
            Double r = FoodFootPrint();
            r += TravelFootPrint();
            r += HomeFootPrint();

            return r;
        }

    }
}
