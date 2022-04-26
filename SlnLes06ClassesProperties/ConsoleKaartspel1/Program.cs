int kaartenPerKleur = 13;
string[] kaartSoort = { "C", "S", "H", "D" };
List<string> Deck = new List<string>();
foreach(var soort in kaartSoort)
{
    for(int i = 0; i < kaartenPerKleur; i++)
    {
        Deck.Add((i+1) + soort);
    }
}
Deck = Shudden();
List<string> SpelerHans = new List<string>();
List<string> SpelerRogier = new List<string>();
while (Deck.Count > 0)
{
    SpelerHans.Add(Deck[Deck.Count-1]);
    Deck.RemoveAt(Deck.Count - 1);
    SpelerRogier.Add(Deck[Deck.Count-1]);
    Deck.RemoveAt(Deck.Count - 1);
}
double hansPunten = 0;
double rogierPunten = 0;

while (SpelerHans.Count > 0 && SpelerRogier.Count > 0)
{
    Console.WriteLine($"Hans legt: {SpelerHans[SpelerHans.Count-1]}\r\nRogier legt: {SpelerRogier[SpelerRogier.Count-1]}");
    if(SpelerHans.Count > SpelerRogier.Count) hansPunten++;
    else if(SpelerHans.Count < SpelerRogier.Count) rogierPunten++;
    else
    {
        hansPunten += 0.5;
        rogierPunten += 0.5;
    }
    SpelerHans.RemoveAt(SpelerHans.Count - 1);
    SpelerRogier.RemoveAt(SpelerRogier.Count - 1);
    Console.WriteLine($"stand: Hans {hansPunten} - Rogier {rogierPunten}");
}
if (hansPunten > rogierPunten) Console.WriteLine("Hans wint dit spel");
else if (hansPunten < rogierPunten) Console.WriteLine("Rogier wint dit spel");
else Console.WriteLine("Gelijk spel");

List<string> Shudden() {
    List<string> shuffleDeck = new List<string>();
    Random r = new Random();
    int p = 0;
    while (Deck.Count > 0)
    {
        p = r.Next(0, Deck.Count);
        shuffleDeck.Add(Deck[p]);
        Deck.Remove(Deck[p]);
    }
    return shuffleDeck;
}
string NeemKaart()
{
    string kaart = Deck[Deck.Count];
    Deck.Remove(Deck[Deck.Count]);
    return kaart;
}
