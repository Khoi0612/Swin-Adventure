using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private List<Path> _paths;

        public Inventory Inventory 
        {
            get
            {
                return _inventory;
            }
            set
            {
                _inventory = value;
            }
        }

        public Location(string name, string desc) : base(new string[] {"room", "here"}, name, desc) 
        {
            _inventory = new Inventory();
            _paths = new List<Path>();
        }

        public List<Path> Paths
        {
            get
            {
                return _paths;
            }
            set
            {
                _paths = value;
            }
        }

        public GameObject? Locate(string id)
        {
            if (this.AreYou(id))
            {
                return this;
            }
            else if (_inventory.HasItem(id))
            {
                return _inventory.Fetch(id);
            }
            return null;
        }

        public Path? LocatePath(string id) 
        {
            foreach (Path p in _paths)
            {
                if (p.AreYou(id))
                {
                    return p;
                }
            }
            return null;
        }
    }
}
