using System;
using System.Collections.Generic;
using System.Text;

namespace WpfEscapeGame
{
    class Actor
    {
        public Actor(string name, string desc)
        {
            Name = name;
            Desc = desc;
        }
        public override string ToString()
        {
            return Name;
        }
        public virtual string Name { get; set; }
        public virtual string Desc { get; set; }
    }
}
