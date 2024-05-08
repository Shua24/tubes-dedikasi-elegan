namespace ConfigurationSettings
{
    public class Configuration
    {
        public string directory { get; set; }
        public string os { get; set; }

        public Configuration() { }

        public Configuration(string os, string directory)
        {
            this.os = os;
            this.directory = directory;
        }
    }
}