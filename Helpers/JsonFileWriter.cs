using GeograficApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
//using RazorPagesDictionaryExample.Models;

namespace GeograficApp.Helpers
{
    public static class JsonFileWriter
    {
        public static void SaveToFile(string filePath, Dictionary<string, Country> data)
        {
            try
            {
                var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving JSON file: {ex.Message}");
            }
        }

        internal static void SaveToFile(Dictionary<string, Country> countries, string jsonFileName)
        {
            throw new NotImplementedException();
        }
    }
}
