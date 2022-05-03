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
            string output = $"\r\n\r\n\r\nKASSATICKET\r\n========\r\nUw kassier: {kassier}";
            foreach (var item in producten)
            {
                output += $"\r\n({item.ProductCode}) { item.ProductName}: {item.PPP}€ x {item.quant} => {item.PPP * item.quant}€";
            }
            output += $"\r\nBetaald met {betaaldMet}\r\n{totaalPrijs}€\r\n\r\n\r\n";
            return output;
        }
    }
}
