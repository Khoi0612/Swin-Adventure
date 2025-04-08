using SwinAdventure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Location _location;

        public override string FullDescription 
        {
            get
            {
                return "You are " + Name + ", "  + base.FullDescription + ". You are carrying:\n" + _inventory.ItemList;
            }
        }

        public Inventory Inventory 
        { 
            get 
            { 
                return _inventory; 
            }
        }

        public Location Location
        {
            get
            {
                return _location;
            }
            set 
            {
                _location = value; 
            }
        }

        public Player(string name, string desc) : base(new string[] {"me", "inventory", "inv"}, name, desc) 
        {
            _inventory = new Inventory();
            _location = new Location("Hallway", "This is a long well lit hallway.");
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
            else if (_location.Inventory.HasItem(id))
            {
                return _location.Locate(id);
            }
            return null;
        }
    }
}
