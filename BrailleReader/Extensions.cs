using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitArray = System.Collections.BitArray;

namespace BrailleReader
{
    public static class ByteExtensions
    {
        private static IDictionary<byte, char> _charMap;
        private static IDictionary<byte, char> CharMap
        {
            get
            {
                return _charMap ?? (_charMap = MakeCharMap());
            }
        }

        public static IDictionary<byte, char> MakeCharMap()
        {
            var map = new Dictionary<byte, char>();

            map.Add(new[] { true }.AsByte(), 'a');
            map.Add(new[] { true, false, true }.AsByte(), 'b');
            map.Add(new[] { true, true }.AsByte(), 'c');
            map.Add(new[] { true, true, false, true }.AsByte(), 'd');
            map.Add(new[] { true, false, false, true }.AsByte(), 'e');
            map.Add(new[] { true, true, true }.AsByte(), 'f');
            map.Add(new[] { true, true, true, true }.AsByte(), 'g');
            map.Add(new[] { true, false, true, true }.AsByte(), 'h');
            map.Add(new[] { false, true, true }.AsByte(), 'i');
            map.Add(new[] { false, true, true, true }.AsByte(), 'j');
            map.Add(new[] { true, false, false, false, true }.AsByte(), 'k');
            map.Add(new[] { true, false, true, false, true }.AsByte(), 'l');
            map.Add(new[] { true, true, false, false, true }.AsByte(), 'm');
            map.Add(new[] { true, true, false, true, true }.AsByte(), 'n');
            map.Add(new[] { true, false, false, true, true }.AsByte(), 'o');
            map.Add(new[] { true, true, true, false, true }.AsByte(), 'p');
            map.Add(new[] { true, true, true, true, true }.AsByte(), 'q');
            map.Add(new[] { true, false, true, true, true }.AsByte(), 'r');
            map.Add(new[] { false, true, true, false, true }.AsByte(), 's');
            map.Add(new[] { false, true, true, true, true }.AsByte(), 't');
            map.Add(new[] { true, false, false, false, true, true }.AsByte(), 'u');
            map.Add(new[] { true, false, true, false, true, true }.AsByte(), 'v');
            map.Add(new[] { false, true, true, true, false, true }.AsByte(), 'w');
            map.Add(new[] { true, true, false, false, true, true }.AsByte(), 'x');
            map.Add(new[] { true, true, false, true, true, true }.AsByte(), 'y');
            map.Add(new[] { true, false, false, true, true, true }.AsByte(), 'z');

            return map;
        }

        public static char AsCharacter(this byte value)
        {
            return CharMap[value];
        }

        public static byte AsByte(this IEnumerable<bool> bits)
        {
            if (bits.Count() > 8) throw new ArgumentException("too many bits");
            return new BitArray(bits.ToArray()).AsByte();
        }

        public static byte AsByte(this BitArray bits)
        {
            var bytes = new byte[1];
            bits.CopyTo(bytes, 0);
            return bytes[0];
        }
    }
}
