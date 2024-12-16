#region Additional Namespaces
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics.Metrics;
using System.Globalization;
using WestWindSystem.BLL;
using WestWindSystem.Entities;
#endregion
#nullable disable

namespace WebApp.Pages.samples
{
    public class RegionQueryOneModel : PageModel
    {
        private readonly RegionServices _regionServices;

        [TempData]
        public string FeedbackMessage { get; set; }

        [BindProperty]
        public List<Region> RegionList { get; set; } = new List<Region>();

        [BindProperty]
        public int SelectRegion { get; set; }

        [BindProperty(SupportsGet = true)] 
        // This is bonded to the input control via the asp-for
        // This is a two-way binding for both out and in, data is moved out and in for you automatically
        // SupportsGet = true will allow this property to be matched to a routing parameter
        // of the same name. **Remember to copy and paste this information**
        public int RegionID { get; set; }

        public RegionQueryOneModel(RegionServices regionServices)
        {
            _regionServices = regionServices;
        }
        public void OnGet()
        {
            // since the internet is astateless environment you need to obtain any list data that is
            // rewuired by your contrils or local logic on every instance of the page being processed
            PopulateList();
            // should create
            if (RegionID > 0)
            {
                Region RegionInfo = _regionServices.Region_GetByID(RegionID);
                if (RegionInfo == null)
                {
                    FeedbackMessage = "Region ID is not valid, no such region on file";
                }
                else
                {
                    FeedbackMessage = $"Region ID: {RegionInfo.RegionId} Description: {RegionInfo.RegionDescription}";
                }
            }
        }
        private void PopulateList()
        {
            // This method will obtain the data for any required list to be used in populating controls for local logic
            RegionList = _regionServices.Region_List();
        }
        // generic failing post handler 
        public void OnPost()
        {
            FeedbackMessage = "WARNING: No OnPost page handler set";
        }
        // This specifies the post method to use in conjunction with asp-page-handler="xxx"
        public IActionResult OnPostFetch()
        {
            if (RegionID < 1)
            {
                FeedbackMessage = "Required: Region ID is a non-zero positive whole number";
            }
            // The receiving "RegionID" is the routing parameter
            // The sending "RegionID" is a BindProperty field
            return RedirectToPage(routeValues: new { RegionID = RegionID });
        }
        public IActionResult OnPostSelect()
        {
            if (SelectRegion > 1)
            {
                FeedbackMessage = "Required: Select a Region to view";
            }
            // The receiving RegionID is a routing parameter
            // The sending SelectRegion is a BindProperty field
            return RedirectToPage(routeValues: new { RegionID = SelectRegion });
        }
        public IActionResult OnPostClear()
        {
            FeedbackMessage = "";
            //RegionID = 0;
            ModelState.Clear();
            return RedirectToPage(routeValues: new {RegionID = (int?)null}); 
                                    // it stays on the page but doesn't do anything with the data, this is a attribute of CRUD
                                    // What we want to do instead of Page(); is to use a redirect.
                                    // Now our data disapears when we use it - if you open the dev tools we can see what is happening to our
                                    // code, click on networking, and put in data and run it, then take a look at hte RegionQueryOne?handler=Fetch
                                    // look at the type and see where the redirect goes, 200 is an OnGet, and the page being reloaded is what the 
                                    // OnGet is getting, our initiator tells us where the request came from, if we look at the fetch request we can
                                    // see our data in the 'payload'. Payload is something that is transferred. 
        }
    }
}
