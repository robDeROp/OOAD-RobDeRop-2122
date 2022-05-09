using System;
using System.Collections.Generic;
using System.Text;

namespace WpfEscapeGame
{
    class Door
    {
        public string Name { get; set; }

        public bool IsLocked { get; set; } = false;
        public Item Key { get; set; }
        public Room LeadsTo { get; set; }
        public Door(string name, bool islcoked, Room leadsto)
        {
            Name = name;
            IsLocked = islcoked;
            LeadsTo = leadsto;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
