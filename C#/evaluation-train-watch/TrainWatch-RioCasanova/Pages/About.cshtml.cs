#region Additional Namespaces
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrainWatchSystem.BLL;
using TrainWatchSystem.Entities;
#endregion
#nullable disable

namespace TrainWebApp.Pages
{
    public class AboutModel : PageModel
    {
        #region Private service fields & class constructor
        private readonly ILogger<AboutModel> _logger;
        private readonly TrainWatchServices _trainWatchServices;

        public AboutModel(ILogger<AboutModel> logger, TrainWatchServices trainWatchServices)
        {
            _logger = logger;
            _trainWatchServices = trainWatchServices;
        }
        #endregion
        public DbVersion BuildVersion { get; set; }

        public void OnGet()
        {
            BuildVersion = _trainWatchServices.GetDbVersion();
        }

    }
}
