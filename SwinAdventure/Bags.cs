using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Bags : Item, IHaveInventory
    {
        private Inventory _inventory;

        public string FullDescription
        {
            get
            {
                return "In the " + Name + " you can see:\n" + _inventory.ItemList;
            }
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

        public Bags(string[] ids, string name, string desc) : base(ids, name, desc) 
        {
            _inventory = new Inventory();
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
    }
}
