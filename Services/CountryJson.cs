using GeograficApp.Helpers;
using GeograficApp.Interfaces;
using GeograficApp.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;


namespace GeograficApp.Services
{
    //public class CountryJson : ICountry
    //{
    //    string JsonFileName = @"C:\Users\mlber\Desktop\GeograficApp\Data\JsonCountry.json";

    //    private readonly Dictionary<string, Country> contries = new Dictionary<string, Country>();
    //    private string currentCountries = Guid.NewGuid().ToString();

    //    public string CountryName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    //    public string Capital { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    //    public string City { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    //    public string Continent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    //    public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    //    public string SpecielPlace { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    //    public CountryJson() 
    //    {
    //        CountryName = AllCountries();

    //        if (CountryName.Keys.Any())
    //        {
    //            currentCountries = CountryName;
    //        }
    //        else
    //        {
    //            currentCountries = ;
    //        }


    //    }

    //    public Dictionary<string, Country> AllCountries()
    //    {
    //        return JsonFileReader.LoadFromFile(JsonFileName);
    //    }

    //    public Dictionary<string, Country> FilterCountries(string criteria)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void AddCountry(Country cntr)
    //    {
    //        if (cntr != null)
    //        {
    //            cntr.CountryName = currentCountries;
    //        }
    //        contries[cntr.CountryName] = cntr;
    //        JsonFileWriter.SaveToFile(countries, JsonFileName);
    //    }

    //    public void RemoveCountry(Country cntr)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void UpdateCountry(Country cntr)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Country GetCountry(string CountryName)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void DeleteCountry(string countryName)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    void ICountry.GetCountry(string countryName)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void AddCountry(ICountry cntr)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CountryJson : ICountry
    {
        string JsonFileName = @"C:\Users\mlber\Desktop\GeograficApp\Data\JsonCountry.json";
        private Dictionary<string, Country> countries;

        public string CountryName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Capital { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string City { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Continent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string SpecielPlace { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public CountryJson()
        {
            countries = AllCountries();
        }

        public Dictionary<string, Country> AllCountries()
        {
            if (System.IO.File.Exists(JsonFileName))
            {
                return JsonFileReader.LoadFromFile(JsonFileName);
            }
            else
            {
                return new Dictionary<string, Country>();
            }
        }

        public Dictionary<string, Country> FilterCountries(string criteria)
        {
            return countries.Values
                .Where(c => c.CountryName.Contains(criteria, StringComparison.OrdinalIgnoreCase) ||
                            c.Capital.Contains(criteria, StringComparison.OrdinalIgnoreCase) ||
                            c.City.Contains(criteria, StringComparison.OrdinalIgnoreCase) ||
                            c.Continent.Contains(criteria, StringComparison.OrdinalIgnoreCase) ||
                            c.Description.Contains(criteria, StringComparison.OrdinalIgnoreCase) ||
                            c.SpecielPlace.Contains(criteria, StringComparison.OrdinalIgnoreCase))
                .ToDictionary(c => c.CountryName, c => c);
        }

        public void AddCountry(Country cntr)
        {
            if (cntr == null || string.IsNullOrWhiteSpace(cntr.CountryName))
            {
                throw new ArgumentException("Invalid country data.");
            }

            countries[cntr.CountryName] = cntr;
            JsonFileWriter.SaveToFile(countries, JsonFileName);
        }

        public void RemoveCountry(Country cntr)
        {
            if (cntr != null && countries.ContainsKey(cntr.CountryName))
            {
                countries.Remove(cntr.CountryName);
                JsonFileWriter.SaveToFile(countries, JsonFileName);
            }
            else
            {
                throw new ArgumentException("Country not found.");
            }
        }

        public void UpdateCountry(Country cntr)
        {
            if (cntr == null || !countries.ContainsKey(cntr.CountryName))
            {
                throw new ArgumentException("Country not found.");
            }

            countries[cntr.CountryName] = cntr;
            JsonFileWriter.SaveToFile(countries, JsonFileName);
        }

        public Country GetCountry(string countryName)
        {
            if (countries.ContainsKey(countryName))
            {
                return countries[countryName];
            }
            else
            {
                throw new ArgumentException("Country not found.");
            }
        }

        public void DeleteCountry(string countryName)
        {
            if (countries.ContainsKey(countryName))
            {
                countries.Remove(countryName);
                JsonFileWriter.SaveToFile(countries, JsonFileName);
            }
            else
            {
                throw new ArgumentException("Country not found.");
            }
        }

        void ICountry.GetCountry(string countryName)
        {
            throw new NotImplementedException();
        }

        public void AddCountry(ICountry country)
        {
            throw new NotImplementedException();
        }
    }

}
