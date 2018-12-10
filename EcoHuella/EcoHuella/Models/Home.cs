using System;
using System.Collections.Generic;
using System.Text;

namespace EcoHuella.Models
{
    public class Home
    {
        public int Id { get; set; }
        public Double Energy { get; set; }
        public Double Size { get; set; }

        public Double FootPrint()
        {
            Double r = Energy * 0.045 / 1000;
            r += Size * 0.103716;
            return r;
        }
    }
}
