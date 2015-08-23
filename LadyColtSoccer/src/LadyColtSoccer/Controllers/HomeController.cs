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
    using Microsoft.AspNet.Mvc;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}