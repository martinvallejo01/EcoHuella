using System;
using System.Collections.Generic;
using System.Text;

namespace EcoHuella.Models
{
    public class Home
    {
        public int HomeID { get; set; }
        public DateTime MeasureTime { get; set; }
        public Double Energy { get; set; }
        public Double Size { get; set; }
        public int Population { get; set; }

        public EcoFootPrint FootPrint { get; set; }
        public int FootPrintID { get; set; }

        public Double CalculateFootPrint()
        {
            Double r = Energy * 0.045 / 1000;
            r += Size * 0.103716;
            r /= Population;
            return r;
        }
    }
}
