
#region Additional Namespaces
using Microsoft.AspNetCore.Mvc.RazorPages;
using WestWindSystem.BLL;
using WestWindSystem.Entities;
#endregion
#nullable disable
namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        #region Private service fields & class constructor
        private readonly ILogger<IndexModel> _logger;
        private readonly BuildVersionServices _buildVersionServices;
        // Services that are registered using AddTransient<>() can be accessed on the constructor of the webpage class (PageModel)
        // This is reffered to as dependency injection. Each registered service that is inherited is listed on the consteruicvtor as a parameter. 
        // ILogger is a  service from microsoft Logging extensions

        // We need to add our required services to this page. Our services will be known by the BLL classname

        // When you add a service to the place you will save the service reference in a
        // private readonly field. This variable will be available to all methiods within this class
        // Just add the service to the contructor and you are good to go for the setup

        public IndexModel(ILogger<IndexModel> logger, BuildVersionServices buildVersionServices)
        {
            _logger = logger;
            _buildVersionServices = buildVersionServices;
        }
        #endregion



        public string MyName { get; set; }
        public BuildVersion BuildVersion { get; set; }


        public void OnGet()
        {
            Random random = new Random();
            int value = random.Next(0, 100);
            if (value % 2 == 0)
            {
                MyName = $"Rio Welcomes you to the Razor World ({value})";
            }
            else
            {
                MyName = null; 
            }
            BuildVersion = _buildVersionServices.GetBuildVersion();
        }
    }
}