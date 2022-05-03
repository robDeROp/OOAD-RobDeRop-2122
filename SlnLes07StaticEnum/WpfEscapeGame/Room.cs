using System;
using System.Collections.Generic;
using System.Text;

namespace WpfEscapeGame
{
    class Room
    {
        public string Name { get; } // read-only: kan maar één keer ingesteld worden
        public string Description { get; }
        public List<Item> Items { get; set; } = new List<Item>();

        public Room(string name, string desc)
        {
            Name = name;
            Description = desc;
        }

    }
}
