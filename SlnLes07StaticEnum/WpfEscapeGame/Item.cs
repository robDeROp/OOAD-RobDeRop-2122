using System;
using System.Collections.Generic;
using System.Text;

namespace WpfEscapeGame
{
    class Item : Actor
    {
        public Actor actor { get; set; }
        public bool IsLocked { get; set; } = false;
        public bool IsPortable { get; set; }

        public Item Key { get; set; }
        public Item HiddenItem { get; set; }
        public Item(string name, string desc, bool IP) : base(name, desc)
        {
            IsPortable = IP;
        }


    }
}
