using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SwinAdventure
{
    public class LookCommand : Command 
    {
        public LookCommand() : base(new string[] { "look"})
        { 
        }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length == 3)
            {
                if (text[0].ToLower() == "look")
                {
                    if (text[1].ToLower() == "at")
                    {
                        if (p.Locate(text[2]) != null) 
                        {
                            return LookAtIn(text[2], p);
                        }
                        else
                        {
                            return "I cannot find the " + text[2];
                        }
                    }
                    else
                    {
                        return "What do you want to look at?";
                    }
                }
                else
                {
                    return "Error in look input";
                }
            }
            else if (text.Length == 5) 
            {
                if (text[0].ToLower() == "look")
                {
                    if (text[1].ToLower() == "at")
                    {
                        if (text[3].ToLower() == "in")
                        {
                            if (p.Locate(text[4]) !=  null)
                            {
                                return LookAtIn(text[2], FetchContainer(p, text[4]));
                            }
                            else
                            {
                                return "I cannot find " + text[4];
                            }
                        }
                        else
                        {
                            return "What do you want to look in?";
                        }
                    }
                    else
                    {
                        return "What do you want to look at?";
                    }
                }
                else
                {
                    return "Error in look input";
                }
            }
            else if (text.Length == 1)
            {
                if (text[0].ToLower() == "look")
                {
                    if (p.Location.Inventory.ItemList != "")
                    {
                        return "You are in a " + p.Location.Name + "\n" + p.Location.FullDescription + "\nIn this room you can see:\n" + p.Location.Inventory.ItemList;
                    }
                    return "You are in a " + p.Location.Name + "\n" + p.Location.FullDescription;
                }
                else
                {
                    return "Error in look input";
                }
            }
            else
            {
                return "I don't know how to look like that";
            }
        }

        public IHaveInventory? FetchContainer(Player p, string containerId)
        {
            if (p.Locate(containerId) == null)
            {
                return p;
            }
            return p.Locate(containerId) as IHaveInventory;
        }

        public string LookAtIn(string thingId, IHaveInventory container)
        {
            if (container.Locate(thingId) == null) 
            {
                return "I cannot find the " + thingId + " in the " + container.Name;
            }
            
            return container.Locate(thingId).FullDescription;
        }

    }
}
