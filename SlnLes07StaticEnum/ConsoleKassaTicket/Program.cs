using System;
using System.Collections.Generic;
namespace ConsoleKassaTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Maak een product");
            Console.WriteLine("Product naam:");
            string Naam_ = Console.ReadLine();
            Console.WriteLine("Product prijs:");
            decimal PPP_ = decimal.Parse(Console.ReadLine()); //PPP = price per piece
            Console.WriteLine("Product code:");
            string Code_ = Console.ReadLine();
            Product product = new Product();
            Console.WriteLine(product.setProduct(Naam_, PPP_, Code_));
        }
    }
}
