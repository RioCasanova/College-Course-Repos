using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#region Addional Namespaces
using WestWindSystem.BLL;
using WestWindSystem.Entities;
#endregion

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        #region Private service fields & class constructor
        private readonly ILogger<IndexModel> _logger;
        private readonly BuildVersionServices _buildVersionServices;
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
        public IndexModel(ILogger<IndexModel> logger, BuildVersionServices buildVersionServices, RegionServices regionServices)
        {
            _logger = logger;
            _buildVersionServices = buildVersionServices;
            _regionServices = regionServices;
        }
        #endregion
        public string MyName { get; set; }

        public BuildVersion BuildVersion { get; set; }
        public Region Region { get; set; }

        public void OnGet()
        {
            Random random = new Random();
            int value = random.Next(0, 100);
            if (value % 2 == 0)
            {
                MyName = $"James welcome you to the Razor World ({value})";
            }
            else
            {
                MyName = null;
            }

            BuildVersion = _buildVersionServices.GetBuildVersion();
        }
    }
}