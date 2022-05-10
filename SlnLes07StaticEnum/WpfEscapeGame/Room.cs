using System;
using System.Collections.Generic;
using System.Text;

namespace WpfEscapeGame
{
    class Room : Actor
    {

        public string ImgSrc { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
        public List<Door> Doors { get; set; } = new List<Door>();
        public Room(string name, string desc) : base(name, desc){}
        public void add_src(string s)
        {
            ImgSrc = s;
        }
    }
}
