using System;
using System.Collections.Generic;
using System.Text;

namespace EcoHuella.Models
{
    public class User
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Mail { get; set; }

        public IList<EcoFootPrint> FootPrints { get; set; }
    }
}
