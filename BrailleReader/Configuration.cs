using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BrailleReader
{
    public class ConfigurationSectionHandler : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, XmlNode section)
        {
            switch (section.Name)
            {
                case "brailleReader": return new BrailleReaderConfigurationSection(section);
                default: throw new ConfigurationErrorsException(string.Format("encountered unknown configuration section name: {0}", section.Name));
            }
        }
    }

    public class ConfigurationService
    {
        #region internals
        private static ConfigurationService _current;
        private static BrailleReaderConfigurationSection _configuration;
        #endregion

        public static ConfigurationService Current
        {
            get { return _current ?? (_current = new ConfigurationService()); }
        }

        public BrailleReaderConfigurationSection Configuration()
        {
            return _configuration
                ?? (_configuration = (BrailleReaderConfigurationSection)ConfigurationManager.GetSection("brailleReader"))
                ?? (_configuration = new BrailleReaderConfigurationSection());
        }
    }

    public class BrailleReaderConfigurationSection : ConfigurationSection
    {
        #region interface
        public bool ConfigurationLoaded { get; set; }
        #endregion

        #region constructors
        public BrailleReaderConfigurationSection() { }

        public BrailleReaderConfigurationSection(XmlNode section)
            : this()
        {
            ParseValues(section);
        }
        #endregion

        #region methods
        private void ParseValues(XmlNode section)
        {
            try
            {
                ConfigurationLoaded = bool.Parse(section.Attributes["configured"].Value);
            }
            catch (Exception e)
            {
                Console.WriteLine("failed to load configuration");
                throw;
            }
        }
        #endregion
    }
}
