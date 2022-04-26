Console.WriteLine("Welkom op de veiling app");
/*Console.WriteLine("Dit zijn de huidige kopers:");
Console.WriteLine("\r\n");*/
List<Koper> kopers = new List<Koper>();
/*kopers.Add( new Koper { ID = 1, FirstName = "Rob", LastName = "De Rop", Email = "Rob.derop@gmail.com" });
kopers.Add( new Koper { ID = 2, FirstName = "Bert", LastName = "De Steen", Email = "Bert.Steen@gmail.com" });
kopers.Add(new Koper { ID = 3, FirstName = "Geert", LastName = "De Vis", Email = "Geert.devis@gmail.com" });
foreach (Koper koper in kopers)
{
    Console.WriteLine($"{koper.ID} - {koper.FirstName} {koper.LastName}");
}
Console.WriteLine("\r\n");
Console.WriteLine("\r\n");*/
Console.WriteLine("De producten:");
Console.WriteLine("\r\n");
List<Item> items = new List<Item>();
items.Add(new Item { Name = "Vaas", Description = "Een mooie ronde Vaas", MinPrice = 32.7 });
items.Add(new Item { Name = "Plastic Zak", Description = "Een vintage plastic zak", MinPrice = 200 });
bool blijvenBieden = true;
while (blijvenBieden)
{
    BiedSequentie();
    Console.WriteLine($"Blijven Bieden?");
    Console.WriteLine("\t[a] Ja");
    Console.WriteLine("\t[b] Nee");

    ConsoleKeyInfo KeuzeLocatie = Console.ReadKey(true);
    Console.WriteLine(KeuzeLocatie.Key);
    if (KeuzeLocatie.Key.ToString() == "B")
    {
        blijvenBieden = false;
    }
}
foreach (Item item in items)
{
    foreach (Bod bod in item.Biedingen)
    {
        Console.WriteLine($"{item.Name} - {bod.kID} - {bod.Price}");
    }
}
BiedingenGesloten();

void BiedingenGesloten()
{
    Bod hoogsteBod = new Bod();
    int i = 0;
    foreach (Item item in items)
    {
        i = 0;
        hoogsteBod.kID = -1;
        hoogsteBod.Price = -1;
        foreach (Bod bod in item.Biedingen)
        {
            if (i == 0)
            {
                hoogsteBod.kID = bod.kID;
                hoogsteBod.Price = bod.Price;
            }
            else if(hoogsteBod.Price < bod.Price)
            {
                hoogsteBod.kID = bod.kID;
                hoogsteBod.Price = bod.Price;
            }
        }
        if(hoogsteBod.kID != -1 && hoogsteBod.Price != -1)
        {
            kopers[hoogsteBod.kID].AangekochteItems.Add(new Item { Name = item.Name, Description = item.Description, MinPrice = item.MinPrice, Biedingen = item.Biedingen, aankoopPrijs = hoogsteBod.Price });
            Console.WriteLine($"Voor het item {item.Name} was {kopers[hoogsteBod.kID].FirstName} {kopers[hoogsteBod.kID].LastName} de hoogste bieder met een bod van {hoogsteBod.Price}");

        }
        else
        {
            Console.WriteLine($"Op het item {item.Name} was er geen bieding");
        }
    
    }

}
void BiedSequentie()
{
    for(int i = 0; i<items.Count; i++)
    {
        Console.WriteLine($"Artikel{i}: {items[i].Name}");
        Console.WriteLine(items[i].Description);
        Console.WriteLine($"Minimum Prijs: {items[i].MinPrice}");
        Console.WriteLine("\t[a] Plaats Bod");
        Console.WriteLine("\t[b] Toon Volgend product");

        ConsoleKeyInfo KeuzeLocatie = Console.ReadKey(true);
        Console.WriteLine(KeuzeLocatie.Key);
        if (KeuzeLocatie.Key.ToString() == "A")
        {
            PlaatsBod(i);
        }
    }
}
void PlaatsBod(int i)
{
    Console.WriteLine("Voornaam:");
    string VN = Console.ReadLine();
    Console.WriteLine("Achternaam:");
    string AN = Console.ReadLine();
    Console.WriteLine("Email:");
    string EM = Console.ReadLine();
    double bod = 0;
    bool bodGoedGekeurd = false;
    while (!bodGoedGekeurd)
    {
        Console.WriteLine("Geef je bod in");
        bod = double.Parse(Console.ReadLine());
        if(bod >= items[i].MinPrice)
        {
            bodGoedGekeurd = true;
        }
        else
        {
            Console.WriteLine("Bod te laag!");
            Console.WriteLine("\t[a] Plaats nieuw bod");
            Console.WriteLine("\t[b] Stop met bieden op dit product");

            ConsoleKeyInfo KeuzeLocatie = Console.ReadKey(true);
            Console.WriteLine(KeuzeLocatie.Key);
            if (KeuzeLocatie.Key.ToString() == "B")
            {
                break;
            }
        }
    }
    if (bodGoedGekeurd)
    {
        int KID = checkIfKoperExists(VN, AN, EM);
        if (KID == -1)
        {
            int t = kopers.Count;
            kopers.Add(new Koper { ID = t, FirstName = VN, LastName = AN, Email = EM});
            Console.WriteLine(items[i].Biedingen.Count);
            items[i].Biedingen.Add(new Bod { kID = t, Price = bod });
        }
        else
        {
            items[i].Biedingen.Add(new Bod { kID = KID, Price = bod });
        }
    }
}
int checkIfKoperExists (string VN, string AN, string EM)
{
    int KID = -1;
    foreach (Koper koper in kopers)
    {
        if (koper.FirstName == VN && koper.LastName == AN && koper.Email == EM)
        {
            KID = koper.ID;
        }
    }
    return KID;
}

public class Koper
{
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public List<Item> AangekochteItems = new List<Item>();
}
public class Item
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double MinPrice { get; set; }

    public List<Bod> Biedingen = new List<Bod>();
    public double aankoopPrijs { get; set; }
}
public class Bod
{
    public int kID { get; set; }
    public double Price { get; set; }
}

