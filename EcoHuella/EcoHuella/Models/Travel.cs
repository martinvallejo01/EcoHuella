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
        public int Car { get; set; }
    }
}
