using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;

namespace GeograficApp.Pages.CatalogCountries
{
    public class CountryViewModel : PageModel
    {
        private readonly ILogger<CountryViewModel> _logger;

        public CountryViewModel(ILogger<CountryViewModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
