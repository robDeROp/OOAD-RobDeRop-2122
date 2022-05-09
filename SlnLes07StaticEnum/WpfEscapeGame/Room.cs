using System;
using System.Collections.Generic;
using System.Text;

namespace WpfEscapeGame
{
    class Room
    {
        public string Name { get; } // read-only: kan maar één keer ingesteld worden
        public string Description { get; }
        public string ImgSrc { get; }
        public List<Item> Items { get; set; } = new List<Item>();
        public List<Door> Doors { get; set; } = new List<Door>();
        public Room(string name, string desc, string imgsrc)
        {
            Name = name;
            Description = desc;
            ImgSrc = imgsrc;
        }

    }
}
