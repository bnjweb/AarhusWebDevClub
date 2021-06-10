using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using Umbraco.Core.Models;
using AarhusWebDevClub.ViewModels;
using Umbraco.Core.Composing.CompositionExtensions;
using Superpower.Parsers;

namespace AarhusWebDevClub.Controllers
{
    public class ContactFormSurfaceController : SurfaceController
    {
        // GET: ContactFormSurface
        public ActionResult Index()
        {

            return PartialView("ContactForm", new ContactForm());
        }  
        

        [HttpPost]
        public ActionResult HandleFormSubmit(ContactForm model)
        {

            IContent comment = Services.ContentService.Create(model.Subject, CurrentPage.Id, "comment");
            comment.SetValue("username", model.Name);
            comment.SetValue("email", model.Email);
            comment.SetValue("subject", model.Subject);
            comment.SetValue("message", model.Message);
            Services.ContentService.Save(comment);


            if (!ModelState.IsValid)

            return CurrentUmbracoPage();
            TempData["success"] = true;
            return RedirectToCurrentUmbracoPage();
        }

     


    }
}