﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EcoHuella.Models
{
    public class EcoFootPrint
    {

        public int FootPrintID { get; set; }
        public Home Home { get; set; }
        public Travel Travel { get; set; }
        public Food Food { get; set; }

        public User User { get; set; }
        public int UserID { get; set; }

        public Double FootPrint()
        {
            Double r = Food.CalculateFootPrint();
            r += Travel.CalculateFootPrint();
            r += Home.CalculateFootPrint();

            return r;
        }

    }
}