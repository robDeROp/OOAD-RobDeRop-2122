using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleVeiling_
{
    class Koper
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<Item> AangekochteItems = new List<Item>();
    }
}
