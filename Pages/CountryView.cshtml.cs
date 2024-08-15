using GeograficApp.Interfaces;
using GeograficApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace GeograficApp.Pages
{
    public class CountryViewModel : PageModel
    {
        private readonly ILogger<CountryViewModel> _logger;

        public CountryViewModel(ILogger<CountryViewModel> logger)
        {
            _logger = logger;
        }

        //public void OnGet()
        //{
        //}
        private ICountry catalog;
        public Dictionary<string, Country> FilterCountries { get; set; }

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }

        public CountryViewModel(ICountry cat)
        {
            catalog = cat;
        }
        public Dictionary<int, Country> Events { get; private set; }
        public Dictionary<string, Country> Country { get; private set; }

        public IActionResult OnGet()
        {
            Country = catalog.AllCountries();
            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                FilterCountries = catalog.FilterCountries(FilterCriteria);
            }
            return Page();
        }

    }
}
