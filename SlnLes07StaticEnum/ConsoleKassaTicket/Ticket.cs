using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleKassaTicket
{
    class Ticket
    {
        List<OrderLine> producten;
        string betaaldMet;
        public string kassier;
        decimal totaalPrijs;
        public string DrukTicket(List<OrderLine> p, string PW, string K, decimal TotPrice){
            string output = "";
            if(p.Count != 0 && PW != "" && K != "")
            {
                producten = p;
                kassier = K;
                betaaldMet = PW;
                totaalPrijs = TotPrice;
                output = "succesfull";
            }
            else
            {
                output = "Error";
            }
            return output;
        }
        public override string ToString()
        {
            string output = $"KASSATICKET\r\n========\r\nUw kassier: {kassier}";
            foreach (var item in producten)
            {
                output += $"\r\n({item.ProductCode}) { item.ProductName}: {item.PPP}";
            }
            output += $"\r\nBetaald met {betaaldMet}\r\n{totaalPrijs}€";
            return output;
        }
    }
}
