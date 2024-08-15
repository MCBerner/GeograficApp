using GeograficApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace GeograficApp.Interfaces
{
    public interface ICountry
    {
        Dictionary<string, Country> AllCountries();
        Dictionary<string, Country> FilterCountries(string criteria);
        void DeleteCountry(string countryName);
        void AddCountry(Country country);
        void UpdateCountry(Country country);
        void GetCountry(string countryName);
        void AddCountry(ICountry country);
        Dictionary<int, Country> FilterEvents(string filterCriteria);

        public string CountryName { get; set; }
        public string Capital { get; set; }
        public string City { get; set; }
        public string Continent { get; set; }
        public string Description { get; set; }
        public string SpecielPlace { get; set; }


    }

    //public interface ICountry
    //{
    //    Dictionary<string, Country> AllCountries();
    //    Dictionary<string, Country> FilterCountries(string criteria);
    //    void AddCountry(Country country);
    //    void RemoveCountry(string countryName);
    //    void UpdateCountry(Country country);
    //    Country GetCountry(string countryName);

    //    public string CountryName { get; set; }
    //    public string Capital { get; set; }
    //    public string City { get; set; }
    //    public string Continent { get; set; }
    //    public string Description { get; set; }
    //    public string SpecielPlace { get; set; }
    //}


}
