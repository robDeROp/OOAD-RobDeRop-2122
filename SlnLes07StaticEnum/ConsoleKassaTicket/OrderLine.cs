using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleKassaTicket
{
    class OrderLine
    {
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public decimal PPP { get; set; }
        public decimal TotalPrice { get; set; }
        public int quant { get; set; }
    }
}
