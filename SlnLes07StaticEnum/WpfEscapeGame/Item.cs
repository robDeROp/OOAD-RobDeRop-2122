using System;
using System.Collections.Generic;
using System.Text;

namespace WpfEscapeGame
{
    class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsLocked { get; set; } = false;
        public bool IsPortable { get; set; }

        public Item Key { get; set; }
        public Item HiddenItem { get; set; }
        public Item(string name, string desc, bool IP)
        {
            Name = name;
            Description = desc;
            IsPortable = IP;
        }
        public override string ToString()
        {
            return Name;
        }

    }
}
