using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.samples
{
    public class BasicDataManagementModel : PageModel
    {

        // create bound properties that are directly tied to a control on the form
        // Attributes = []

        [BindProperty]
        public int MyNum { get; set; }
        [BindProperty]
        public string FavouriteCourse { get; set; }
        [BindProperty]
        public string Comments { get; set; }


        // Attribute TempData is required if you are processing multiple requests (OnPost followed by an OnGet to retain data within the property.
       // [TempData]
        public string FeedBack { get; set; }

        public void OnGet()
        {
            // executes for a Get request
            // the first time the page is requested an automatic Get request is sent
            // excellent "event" to use to do any initialization to your webpage display
            //      as the page is shpw for the first time.
        }
        public void OnPostA()
        {
            // processing the OnPost request - request of the forms (method="post")
            // the return data type can be void or IActionResult
            // The OnPost request is the request from a buttom that has not indicated a 
            //  specific process Post using the asp-page-handler
            // logic that you wish to accomplish should be isolated to the action
            //      desired for the button
            // FeedBack = $"Number is {MyNum}, Course {FavouriteCourse}, Comments {Comments}";
            FeedBack = "button A was pressed";
        }
        public void OnPostB()
        {
            // FeedBack = $"Number is {MyNum}, Course {FavouriteCourse}, Comments {Comments}";
            FeedBack = "button B was pressed";
        }
    }
}
