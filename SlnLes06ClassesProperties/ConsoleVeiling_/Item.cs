using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleVeiling_
{
    class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double MinPrice { get; set; }

        public List<Bod> Biedingen = new List<Bod>();
        public double aankoopPrijs { get; set; }
    }
}
