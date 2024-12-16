#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Samples
{
    public class BasicDataManagementModel : PageModel
    {
        //  create bound properties that are directly tied to a control on the form
        [BindProperty]
        public int MyNum { get; set; }
        [BindProperty]
        public string FavouriteCourse { get; set; }
        [BindProperty]
        public string Comments { get; set; }


        //  Attribute TempData is requred IF you are processing multiple requests (OnPost
        //      followed by OnGet() to retain data within the property
        // [TempData]
        public string FeedBack { get; set; }

        public void OnGet()
        {
            //  executes for a Get request
            //  the first time the page is requested an automatic Get request is sent
            //  execelletnt "evernt" to use to do any intialization to your web page display
            //      as the page is shown for the first time.
        }

        public void OnPostA()
        {
            //  process the OnPost request of the form (method = "post")
            //  the return data type can be void or IActionResult
            //  OnPost request is the request from a <button> that has NOT indicated a 
            //    specific process Post using the asp-page-handler
            //  logic the you wish to accomplish should be isolatted to the actions
            //    desired for the button.
            //  FeedBack = $"Number {MyNum}, Course {FavouriteCourse} Comments {Comments}";
            FeedBack = "Button A was pressed";
        }

        public void OnPostB()
        {
            //  process the OnPost request of the form (method = "post")
            //  the return data type can be void or IActionResult
            //  OnPost request is the request from a <button> that has NOT indicated a 
            //    specific process Post using the asp-page-handler
            //  logic the you wish to accomplish should be isolatted to the actions
            //    desired for the button.
            //  FeedBack = $"Number {MyNum}, Course {FavouriteCourse} Comments {Comments}";
            FeedBack = "Button B was pressed";
        }
    }
}
