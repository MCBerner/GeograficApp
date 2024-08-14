using GeograficApp.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
//using RazorPagesDictionaryExample.Models;

namespace GeograficApp.Helpers
{
    public static class JsonFileReader
    {
        public static Dictionary<string, Country> LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new Dictionary<string, Country>();
            }

            try
            {
                var json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<Dictionary<string, Country>>(json) ?? new Dictionary<string, Country>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading JSON file: {ex.Message}");
                return new Dictionary<string, Country>();
            }
        }
    }
}
