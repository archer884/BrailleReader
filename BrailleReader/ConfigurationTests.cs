using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrailleReader
{
    [TestClass]
    public class ConfigurationTests
    {
        [TestMethod]
        public void Test_001_LoadConfiguration()
        {
            var configuration = ConfigurationService.Current.Configuration();
            Assert.IsTrue(configuration.ConfigurationLoaded);
        }
    }
}
