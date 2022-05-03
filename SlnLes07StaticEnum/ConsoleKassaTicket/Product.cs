using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleKassaTicket
{
     public class Product
        {
        public string naam;
        public decimal eenheidsPrijs;
        public string code;
        public string setProduct(string n, decimal e, string c)
        {
            naam = n;
            eenheidsPrijs = e;
            if (ValideerCode(c))
            {
                code = c;
                return "succesfull creation of product";
            }
            else
            {
                return "\r\n \r\n \r\n error: product code doesnt start with 'p' and must have a length of 6 chars! \r\nProduct was created without code";
            }
        }
        public bool ValideerCode(string c)
        {
            bool validCode = false;
            if (c.Length == 6)
            {
                if(c.Substring(0, 1) == "P")
                {
                    validCode = true;
                }
            }
            return validCode;
        }
        public override string ToString()
        {
            string returningValue = $"({code}) {naam} {eenheidsPrijs}";
            return returningValue;
        }
    }


}
