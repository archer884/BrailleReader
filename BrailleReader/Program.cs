using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrailleReader
{
    class Program
    {
        static void Main(string[] args)
        {
            var top = Console.ReadLine();
            top = string.IsNullOrWhiteSpace(top) ? "O. O. O. O. O. .O O. O. O. OO" : top;
            
            var middle = Console.ReadLine();
            middle = string.IsNullOrWhiteSpace(middle) ? "OO .O O. O. .O OO .O OO O. .O" : middle;

            var bottom = Console.ReadLine();
            bottom = string.IsNullOrWhiteSpace(bottom) ? ".. .. O. O. O. .O O. O. O. .." : bottom;

            if (top.Length != middle.Length || top.Length != bottom.Length)
                throw new ArgumentException("all inputs must be of equal length");

            var brailleString = new BrailleString(top, middle, bottom);

            Console.WriteLine(brailleString);
        }
    }
}
