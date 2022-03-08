using System;

namespace ConsoleCsv
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] Games = { "Schaken", "Backgammon", "Dammen" };
            string[] Players = { "Paule", "Leroy", "Amalie", "Veradis", "Kristel", "Veronique", "Roshelle", "Anthe", "Starr", "Kev", "Adolpho", "Torie", "Rodrick", "Andras", "Mathilde", "Cesaro", "Blake", "Trixy", "Angeli", "Evvie", "Lothaire", "Kathie", "Mildrid", "Sybila", "Amandi", "Garrik", "Manny", "Graehme", "Ralph", "Jermaine", "Hyacintha", "Gena", "Jolene", "Mile", "Lelah", "Deanne", "Corrie", "Peta", "Guthrey", "Land", "Fin", "Ilyssa", "Melanie", "Cariotta", "Farley", "Dre", "Zita", "Jacky", "Caryn", "Elisa", "Deidre", "Julianna", "Madelina", "Chevy", "Kipper", "Steward", "Morgun", "Merl", "Abbie", "Ileane", "Darius", "Richy", "Sam", "Torrin", "Lonnie", "Pauli", "Milty", "Elisha", "Colman", "Viviyan", "Gordon", "Ewen", "Magdalena", "Gabriello", "Kenton", "Purcell", "Prent", "Georgetta", "Tatiania", "Jamil", "Horton", "Hi", "Cloris", "Ave", "Chris", "Edna", "Nealon", "Vanessa", "Sybila", "Warren", "Lorry", "Daniella", "Kirsten", "Lowrance", "Janene", "Jorrie", "Jessalin", "Devi", "Coletta" };
            int numberOfGames = 100;
            int numberOfRounds = 3;
            Random rnd = new Random();
            int p1 = 0;
            int p2 = 0;
            int RoundP1 = 0;
            int Game = 0;
            for (int i = 0; i < 100; i++)
            {
                p1 = rnd.Next(0, 99);
                p2 = rnd.Next(0, 99);
                while(p1 == p2) p2 = rnd.Next(0, 100);
                RoundP1 = rnd.Next(0, 4);
                Game = rnd.Next(0, 3);
                Console.WriteLine($"{i+1};{Players[p1]};{Players[p2]};{Games[Game]};{RoundP1}-{3 - RoundP1}");
            }
        }
    }
}
