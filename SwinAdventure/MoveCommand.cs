using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] {"move", "go", "head", "leave"})
        { 
        }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length <= 3)
            {
                if (text[0].ToLower() == "move")
                {  
                    try
                    {
                        return GetPath(p.Location, text[1]);
                    }
                    finally 
                    {
                        if (p.Location.LocatePath(text[1]) is not null)
                        {
                            p.Location.LocatePath(text[1]).Move(p);
                        }
                    }
                }
                else
                {
                    return "Error in move input";
                }  
            }
            return "I don't know how to move like that";
        }

        public string GetPath(Location location, string pathId)
        {
            if (location.LocatePath(pathId) == null) 
            {
                return "There are no path in this direction";
            }
            return location.LocatePath(pathId).FullDescription;
        }
    }
}
