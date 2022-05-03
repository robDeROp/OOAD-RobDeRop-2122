using System;
using System.Collections.Generic;
namespace ConsoleKassaTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> producten = new List<Product>();
            Product productaa = new Product();
            productaa.setProduct("Banaan", decimal.Parse("2,5"), "P12345");
            producten.Add(productaa);
            productaa.setProduct("Appel", decimal.Parse("3,5"), "P12346");
            producten.Add(productaa);
            productaa.setProduct("Peer", decimal.Parse("1,5"), "P12347");
            producten.Add(productaa);
            while (1 != 2)
            {
                Console.WriteLine("Welkom op de Kassa APP");
                Console.WriteLine("Wat wil je doen?");
                Console.WriteLine("\n[A] Maak een product aan");
                Console.WriteLine("\n[B] Toon Producten");
                Console.WriteLine("\n[C] Koop Producten");
                Console.WriteLine("\n[esc] Sluit de app");
                ConsoleKeyInfo KeyKeuze = Console.ReadKey();
                string Key = KeyKeuze.Key.ToString();
                Console.WriteLine($"We openen u keuze: {Key}");
                if (Key == "A")
                {
                    Console.WriteLine("Product naam:");
                    string Naam_ = Console.ReadLine();
                    Console.WriteLine("Product prijs:");
                    decimal PPP_ = decimal.Parse(Console.ReadLine()); //PPP = price per piece
                    Console.WriteLine("Product code:");
                    string Code_ = Console.ReadLine();
                    Console.WriteLine(productaa.setProduct(Naam_, PPP_, Code_));
                    producten.Add(productaa);
                }
                else if (Key == "B")
                {
                    Console.WriteLine("\r\n Product inventory:\r\n");
                    foreach (var product in producten)
                    { 
                        Console.WriteLine(product.ToString());
                    }
                }
                else if (Key == "C")
                {
                    List<OrderLine> Bestelling = new List<OrderLine>();
                    Console.WriteLine("\r\n Kassa Ticket Genereren\r\n");
                    int i = 0;
                    foreach (var product in producten)
                    {
                        Console.WriteLine("["+i+"] "+product.ToString());
                        Console.WriteLine("Wilt u dit product aankopen?");
                        Console.WriteLine("\n[A] JA");
                        Console.WriteLine("\n[B] NEE");
                        ConsoleKeyInfo KeyKeuze2 = Console.ReadKey();
                        string Key2 = KeyKeuze2.Key.ToString();
                        Console.WriteLine(Key2);
                        if(Key2 == "A")
                        {
                            Console.WriteLine("Geef de hoeveelheid in dat u wil bestellen");
                            int aantal = int.Parse(Console.ReadLine());
                            Bestelling.Add(new OrderLine { ProductName = product.naam, quant = aantal, PPP = product.eenheidsPrijs, ProductCode = product.code, TotalPrice = (product.eenheidsPrijs * aantal) });
                        }
                        else
                        {
                            Console.WriteLine("Neen, volgend product");
                        }
                        i++;
                    }
                    Console.WriteLine("Bestelling afronden");
                    Console.WriteLine("Wie is de kassier?");
                    string Kassier = Console.ReadLine();
                    Console.WriteLine("Hoe betaal je?");
                    Console.WriteLine("[a] =" + Betaalwijze.Cash);
                    Console.WriteLine("[b] =" + Betaalwijze.Visa);
                    Console.WriteLine("[c] =" + Betaalwijze.Bancontanct);

                    ConsoleKeyInfo KeyKeuze3 = Console.ReadKey();
                    string Key3 = KeyKeuze.Key.ToString();

                    string PayWay = Betaalwijze.Cash.ToString();
                    if(Key3 == "B")
                    {
                        PayWay = Betaalwijze.Visa.ToString();
                    }
                    else if (Key3 == "C")
                    {
                        PayWay = Betaalwijze.Bancontanct.ToString();
                    }
                    Ticket T = new Ticket();
                    decimal TotPrice = 0;
                    T.DrukTicket(Bestelling, PayWay, Kassier, TotPrice);
                    Console.WriteLine(T.ToString());
                }
                Console.WriteLine("Proces beindigd, restarting process");
            }


        }
        public enum Betaalwijze { Cash, Visa, Bancontanct};
    }
}
