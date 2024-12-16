using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;
using System;

namespace TrainWebApp.Pages.ContactUs
{
    public class ContactUsModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string ContactReason { get; set; }
        [BindProperty]
        public string MessageTitle { get; set; }
        [BindProperty]
        public string Message { get; set; }

        [TempData]
        public string FeedBack { get; set; }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            FeedBack = $"Email: {Email}, Reason for contact: {ContactReason}, Subject: {MessageTitle}, Message: {Message}";
        }
    }
}
