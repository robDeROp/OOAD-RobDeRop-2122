using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleKassaTicket
{
     public class Product
        {
        string naam;
        decimal eenheidsPrijs;
        string code;
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
                return "error: product code doesnt start with 'p' and must have a length of 9 chars! \r\nProduct was created without code";
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
            return naam + " " + eenheidsPrijs;
        }
    }


}
