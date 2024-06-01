using System;
using System.IO;
using System.Text.Json;

namespace ConfigurationSettings
{
    public class ConfigurationReader
    {
        public Configuration config;
        public const string filePath = @"config.json";

        public ConfigurationReader()
        {
            try
            {
                ReadConfig();
            } 
            catch (Exception)
            {
                SetDefaults();
                NewConfiguration();
            }
        }

        private Configuration ReadConfig()
        {
            string jsonConfig = File.ReadAllText(filePath);
            config = JsonSerializer.Deserialize<Configuration>(jsonConfig);
            return config;
        }

        private void SetDefaults()
        {
            OperatingSystem os = Environment.OSVersion;
            PlatformID kern = os.Platform;

            switch (kern)
            {
                case PlatformID.Win32NT: config = new Configuration("Windows", @"D:\CSV\"); break;
                case PlatformID.MacOSX: config = new Configuration("Mac OSX", @"/home/$USER/CSV/"); break;
            }
        }

        private void NewConfiguration()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            string jsonStr = JsonSerializer.Serialize(config, options);
            File.WriteAllText(filePath, jsonStr);
        }

        public void ChangeConfig(string newPath)
        {
            config.directory = newPath; 
        }
    }
}