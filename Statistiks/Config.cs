using System;

namespace ConfigurationSettings
{
    public class Configuration
    {
        public string directory { get; set; }

        public Configuration() { }

        public Configuration(string directory)
        {
            this.directory = directory;
        }
    }
}