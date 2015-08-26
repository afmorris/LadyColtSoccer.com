// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Veritix" file="HomeController.cs">
//   Copyright (c) Veritix. All rights reserved.
// </copyright>
// <author>
//   Tony.Morris
// </author>
// <modified>
//   2015-08-22 8:12 PM
// </modified>
// <created>
//   2015-08-20 10:00 PM
// </created>
// --------------------------------------------------------------------------------------------------------------------

namespace LadyColtSoccer.Controllers
{
    using System;
    using LadyColtSoccer.Models;
    using Microsoft.AspNet.Mvc;
    using FormContext = LadyColtSoccer.Models.FormContext;

    public class HomeController : Controller
    {
        private readonly FormContext context;

        public HomeController(FormContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return this.View(new FormSubmission());
        }

        [Route("FormSubmit")]
        public IActionResult FormSubmit(FormSubmission model)
        {
            var recaptcha = this.Request.Form["g-recaptcha-response"];
            // TODO: Check if this is a valid anti-bot response

            this.context.Submissions.Add(model);
            this.context.SaveChanges();

            return this.RedirectToAction("Confirmation");
        }

        [Route("Confirmation")]
        public IActionResult Confirmation()
        {
            return this.View();
        }
    }
}