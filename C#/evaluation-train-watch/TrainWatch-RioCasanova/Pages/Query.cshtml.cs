#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
#region Addional Namespaces
using TrainWatchSystem.BLL;
using TrainWatchSystem.Entities;
#endregion

namespace TrainWebApp.Pages
{
    public class QueryModel : PageModel
    {
        #region Private service fields & class constructor
        private readonly ILogger<IndexModel> _logger;
        private readonly TrainWatchServices _trainWatchServices;
        private readonly RollingStockServices _rollingStockServices;
        private readonly RailCarTypeServices _railCarTypeServices;

        public QueryModel(ILogger<IndexModel> logger,
                                    TrainWatchServices trainWatchServices,
                                    RollingStockServices rollingStockServices, RailCarTypeServices railCarTypeServices)
        {
            _logger = logger;
            _trainWatchServices = trainWatchServices;
            _rollingStockServices = rollingStockServices;
            _railCarTypeServices = railCarTypeServices;
        }
        #endregion

        #region Properties
        [TempData]
        public string FeedbackMessage { get; set; }

        [BindProperty]
        public int SelectRailCar { get; set; }

        [BindProperty]
        public List<RollingStock> RailCarTypeData { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? RailCarTypeID { get; set; }

        [BindProperty]
        public List<RollingStock> RollingStockData { get; set; }

        [BindProperty]
        public List<RailCarTypes> RailCarTypeList { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SearchArg { get; set; }

        #endregion
        public void OnGet()
        {
            RailCarTypeList = _railCarTypeServices.RailCarTypes_List();

            if (SelectRailCar != 0)
            {
                RailCarTypeData = _rollingStockServices.RailCar_GetByID(RailCarTypeID);
            }
            if (!string.IsNullOrWhiteSpace(SearchArg))
            {
                RollingStockData = _rollingStockServices.GetByPartialDescription(SearchArg);
            }
        }

        #region OnPost
        public IActionResult OnPostSearch()
        {
            if (string.IsNullOrWhiteSpace(SearchArg))
            {
                FeedbackMessage = "Required:  Search argument is empty";
            }
            return RedirectToPage(routeValues: new { SearchArg = SearchArg });
        }
        public IActionResult OnPostSelect()
        {      
            return RedirectToPage(routeValues: new { RailCarTypeID = SelectRailCar });
        }
        public IActionResult OnPostClear()
        {
            FeedbackMessage = ""; 
            ModelState.Clear();
            return RedirectToPage(routeValues: new { SearchArg = (string?)null });
        }
        #endregion
    }
}
