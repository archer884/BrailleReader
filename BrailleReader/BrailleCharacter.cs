using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrailleReader
{
    class BrailleCharacter
    {
        public char Value { get; set; }

        public BrailleCharacter() { }

        public BrailleCharacter(IEnumerable<bool> value)
        {
            Value = value.AsByte().AsCharacter();
        }
    }
}
