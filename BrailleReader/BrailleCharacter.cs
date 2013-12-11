using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20131211
{
    class BrailleCharacter
    {
        private byte _value;
        public char Value
        {
            get
            {
                return _value.AsCharacter();
            }
        }

        public BrailleCharacter() { }

        public BrailleCharacter(IEnumerable<bool> value)
        {
            _value = value.AsByte();
        }
    }
}
