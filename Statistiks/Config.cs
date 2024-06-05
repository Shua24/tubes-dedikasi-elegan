namespace ConfigurationSettings
{
    public class Configuration
    {
        public string Directory { get; set; }
        public string Os { get; set; }

        public Configuration() { }

        public Configuration(string os, string directory)
        {
            Os = os;
            Directory = directory;
        }
    }
}