using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrailleReader
{
    [TestClass]
    public class BrailleStringTests
    {
        bool[] h = new[] { true, false, true, true, false, false };
        bool[] e = new[] { true, false, false, true, false, false };
        bool[] l = new[] { true, false, true, false, true, false };
        bool[] o = new[] { true, false, false, true, true, false };
        bool[] w = new[] { false, true, true, true, false, true };
        bool[] r = new[] { true, false, true, true, true, false };
        bool[] d = new[] { true, true, false, true, false, false };

        [TestMethod]
        public void Test_001_BraileCharacter()
        {
            Assert.AreEqual('h', new BrailleCharacter(h).Value);
            Assert.AreEqual('e', new BrailleCharacter(e).Value);
            Assert.AreEqual('l', new BrailleCharacter(l).Value);
            Assert.AreEqual('o', new BrailleCharacter(o).Value);
            Assert.AreEqual('w', new BrailleCharacter(w).Value);
            Assert.AreEqual('r', new BrailleCharacter(r).Value);
            Assert.AreEqual('d', new BrailleCharacter(d).Value);
        }

        [TestMethod]
        public void Test_002_BrailleString()
        {
            var brailleString = new BrailleString(new[] { h, e, l, l, o, w, o, r, l, d });
            Assert.AreEqual("helloworld", brailleString.ToString());
        }

        [TestMethod]
        public void Test_003_StringParsing()
        {
            var brailleString = new BrailleString("00 0. 00 0. 00 0. 0.", "0. .. .. .. .0 .0 ..", ".. 00 .. 0. 00 0. 00");
            Assert.AreEqual("fuckyou", brailleString.ToString());
        }
    }
}
