using System;
using System.Collections.Generic;
using System.Text;

namespace WpfEscapeGame
{
    class Door : Actor
    {
        public Actor actor { get; set; }

        public bool IsLocked { get; set; } = false;
        public Item Key { get; set; }
        public Room LeadsTo { get; set; }
        public Door(string name, string desc , bool islcoked, Room leadsto) : base(name, desc)
        {
            IsLocked = islcoked;
            LeadsTo = leadsto;
        }
    }
}
