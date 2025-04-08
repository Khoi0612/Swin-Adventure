using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class IdentifiableObject
    {
        private List<string> _identifiers;

        public string FirstId
        {
            get
            {
                if (_identifiers.Count == 0)
                {
                    return "";
                }
                else
                {
                    return _identifiers[0];
                }
            }
        }

        public IdentifiableObject(string[] idents)
        {
            _identifiers = new List<string> { };
            foreach (string s in idents)
            {
                _identifiers.Add(s.ToLower());
            }
        }

        public bool AreYou(string id)
        {
            foreach (string s in _identifiers)
            {
                if (s == id.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        public void AddIdentifier(string id)
        {
            _identifiers.Add(id.ToLower());
        }
    }
}
