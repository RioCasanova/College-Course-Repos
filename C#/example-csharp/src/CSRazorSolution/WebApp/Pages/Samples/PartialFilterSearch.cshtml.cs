#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
#region Addional Namespaces
using WestWindSystem.BLL;
using WestWindSystem.Entities;
#endregion

namespace WebApp.Pages.Samples
{
    public class PartialFilterSearchModel : PageModel
    {
        #region Private service fields & class constructor
        private readonly ILogger<IndexModel> _logger;
        private readonly TerritoryServices _territoryServices;
        private readonly RegionServices _regionServices;
        /*
         *  Services that are registered using AddTransisent<>()
         *      can be accessed on the constructor of the web page class (PageMode)
         *  This is referred to as Dependency Injection
         *  Each register service that is inhected is listed on the constructor as a parameter
         *  ILogger is a service from Microsoft Logging extensions
         *  
         *  We need to add our requried service(s) to this page
         *  Our services will be know by the BLL class name
         *  
         *  When you add a service to the page, you will save the service
         *      reference in a private readonly field
         *  This variable will be available to all methods within this class.
        */
        public PartialFilterSearchModel(ILogger<IndexModel> logger,
                                            TerritoryServices territoryServices,
                                            RegionServices regionServices)
        {
            _logger = logger;
            _territoryServices = territoryServices;
            _regionServices = regionServices;
        }
        #endregion

        [TempData]
        public string Feedback { get; set; }

        [BindProperty(SupportsGet = true)]
        public int RegionID { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchArg { get; set; }

        public List<Territory> TerritoryInfo { get; set; }

        [BindProperty]
        public List<Region> RegionList { get; set; }
        public void OnGet()
        {
            //  Obtain the data list for the Region dropdownlist (select tag)
            RegionList = _regionServices.Region_List();
            if (!string.IsNullOrWhiteSpace(SearchArg))
            {
                TerritoryInfo = _territoryServices.GetByPartialDescription(SearchArg);
            }
        }

        public IActionResult OnPostFetch()
        {
            if (string.IsNullOrWhiteSpace(SearchArg))
            {
                Feedback = "Required:  Search argument is empty";
            }
            return RedirectToPage(new { SearchArg = SearchArg });
        }

        public IActionResult OnPostClear()
        {
            Feedback = "";
            //RegionID = 0;
            ModelState.Clear();
            return RedirectToPage(new { SearchArg = (string?)null});
        }
    }
}
