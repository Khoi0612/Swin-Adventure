using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class CommandProcessor
    {
        private List<Command> _commands;

        public CommandProcessor() 
        {
            _commands = new List<Command>();
            LookCommand _lookCommand = new LookCommand();
            MoveCommand _moveCommand = new MoveCommand();
            _commands.Add( _lookCommand );
            _commands.Add( _moveCommand );
            
        }

        public string Process(Player p, string[] command)
        {
            string cmd = "";
            foreach (string s in command)
            {
                cmd = cmd + " " + s;
            }

            switch (command[0])
            {
                case "look":
                    return _commands[0].Execute(p,command);
                case "move":
                    return _commands[1].Execute(p,command);
            }
            return "I don't understand" + cmd;  
        }
    }
}
