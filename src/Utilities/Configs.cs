using System;
using System.IO;
using Newtonsoft.Json;

namespace SharpCalc.Utilities
{
    // https://stackoverflow.com/a/60436834

    public static class Configs
    {
        public static void UpdateSetting<T>(string sectionPathKey, T value, string custom = "none")
        {
            string filePath;

            if (custom == "none") { filePath = "Configs/config.json"; }
            else { filePath = $"Configs/config.{custom}.json"; }

            try
            {
                string json = File.ReadAllText(filePath);
                dynamic jsonObj = JsonConvert.DeserializeObject(json);

                SetValueRecursively(sectionPathKey, jsonObj, value);

                string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                File.WriteAllText(filePath, output);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing app settings | {0}", ex.Message);
            }
        }

        private static void SetValueRecursively<T>(string sectionPathKey, dynamic jsonObj, T value)
        {
            // Split the string at the first ':' character
            var remainingSections = sectionPathKey.Split(":", 2);
            
            var currentSection = remainingSections[0];
            if (remainingSections.Length > 1)
            {
                // Continue with the proccess, moving down the tree
                var nextSection = remainingSections[1];
                SetValueRecursively(nextSection, jsonObj[currentSection], value);
            }
            else
            {
                // We've got to the end of the tree, set the value
                jsonObj[currentSection] = value;
            }
        }
    }
}