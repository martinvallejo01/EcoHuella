using System;
using System.Collections.Generic;
using System.Text;

namespace EcoHuella.Models
{
    public class Travel
    { 
        public int Id;

        public int Bus { get; set; }
        public int AirPlane { get; set; }
        public int CarKm { get; set; }
        public double CarEngine { get; set; }
        public double CarGas { get; set; }
        public double CarPeople { get; set; }

        public double CalculateFootPrint()
        {
            double footPrint = CarKm * CarPeople * CarEngine * CarGas;
            footPrint /= 6.75;
            footPrint += AirPlane * 500;
            footPrint += Bus * 40;
            return footPrint;
        }

    }
}
