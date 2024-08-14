using GeograficApp.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;


namespace GeograficApp.Models
{

    public class Country : ICountry
    {
        public string CountryName { get; set; }
        public string Capital { get; set; }
        public string City { get; set; }
        public string Continent { get; set; }
        public string Description { get; set; }
        public string SpecielPlace { get; set; }

        private Dictionary<string, Country> countries = new Dictionary<string, Country>();

        //public Country() {}


        public Country(string countryName, string capital, string city, string continent, string description, string specielPlace)
        {
            CountryName = countryName;
            Capital = capital;
            City = city;
            Continent = continent;
            Description = description;
            SpecielPlace = specielPlace;
        }

        public override string ToString()
        {
            return $"Land: {CountryName}, Hovedstad: {Capital}, By: {City}, Kontinent: {Continent}, Beskrivelse: {Description}, Kendte steder: {SpecielPlace}";
        }

        public Dictionary<string, Country> AllCountries()
        {
            return new Dictionary<string, Country>(countries);
        }

        public Dictionary<string, Country> FilterCountries(string criteria)
        {
            var filteredCountries = new Dictionary<string, Country>();

            foreach (var country in countries.Values)
            {
                if (country.CountryName.Contains(criteria, StringComparison.OrdinalIgnoreCase) ||
                    country.Capital.Contains(criteria, StringComparison.OrdinalIgnoreCase) ||
                    country.City.Contains(criteria, StringComparison.OrdinalIgnoreCase) ||
                    country.Continent.Contains(criteria, StringComparison.OrdinalIgnoreCase) ||
                    country.Description.Contains(criteria, StringComparison.OrdinalIgnoreCase) ||
                    country.SpecielPlace.Contains(criteria, StringComparison.OrdinalIgnoreCase))
                {
                    filteredCountries[country.CountryName] = country;
                }
            }

            return filteredCountries;
        }

        void ICountry.AddCountry(Country country)
        {
            if (!countries.ContainsKey(country.CountryName))
            {
                countries[country.CountryName] = country;
            }
            else
            {
                throw new ArgumentException("Country already exists.");
            }
        }

        void ICountry.UpdateCountry(Country country)
        {
            throw new NotImplementedException();
        }

        void ICountry.GetCountry(string countryName)
        {
            throw new NotImplementedException();
        }

        void ICountry.DeleteCountry(string countryName)
        {
            throw new NotImplementedException();
        }

        void ICountry.AddCountry(ICountry country)
        {
            throw new NotImplementedException();
        }
    }


}




  
 

   

    

