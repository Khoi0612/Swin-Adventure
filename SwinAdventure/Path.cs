using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Path : GameObject
    {

        private Location _destination;

        public Path(string[] ids, string name, string desc, Location dest) : base(ids, name, desc)
        {
            _destination = dest;
        }

        public void Move(Player p)
        {
            p.Location = _destination;
        }
    }
}
