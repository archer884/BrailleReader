using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20131211
{
    class BrailleString
    {
        private BrailleCharacter[] Characters { get; set; }

        public BrailleString() { }

        public BrailleString(string top, string middle, string bottom)
            : this(ParseCharacters(top, middle, bottom))
        {
        }

        public BrailleString(IEnumerable<IEnumerable<bool>> characters)
        {
            Characters = characters.Select(bits => new BrailleCharacter(bits)).ToArray();
        }

        private static IEnumerable<IEnumerable<bool>> ParseCharacters(string top, string middle, string bottom)
        {
            var topPairs = top.Split(' ');
            var middlePairs = middle.Split(' ');
            var bottomPairs = bottom.Split(' ');

            for (int i = 0; i < topPairs.Length; i++)
            {
                yield return topPairs[i].Select(Bump)
                    .Concat(middlePairs[i].Select(Bump))
                    .Concat(bottomPairs[i].Select(Bump));
            }
        }

        private static bool Bump(char character)
        {
            return character == '0'
                || character == 'O';
        }

        public override string ToString()
        {
            return Characters.Aggregate(new StringBuilder(), (a, b) => a.Append(b.Value)).ToString();
        }
    }
}
