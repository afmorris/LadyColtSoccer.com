// <author>
//   Tony Morris
// </author>
// <modified>
//   2015-08-29 10:58 PM
// </modified>
// <created>
//   2015-08-23 11:58 AM
// </created>

namespace LadyColtSoccer.Controllers
{
    using System;
    using System.Data.SqlClient;

    using Dapper;

    using LadyColtSoccer.Models;

    using Microsoft.AspNet.Mvc;
    using Microsoft.Framework.OptionsModel;

    public class HomeController : Controller
    {
        private readonly IOptions<AppSettings> appSettings;

        public HomeController(IOptions<AppSettings> appSettings)
        {
            this.appSettings = appSettings;
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

            model.DateEntered = DateTime.UtcNow;
            using (var connection = new SqlConnection(this.appSettings.Options.DataConnectionString))
            {
                connection.Execute(
                    "INSERT INTO [FormSubmission] ([Name], [NumberOfTickets], [ContactChoice], [PhoneNumber], [EmailAddress], [AdditionalInformation], [DateEntered]) VALUES (@Name, @NumberOfTickets, @ContactChoice, @PhoneNumber, @EmailAddress, @AdditionalInformation, @DateEntered)",
                    model);
            }

            return this.RedirectToAction("Confirmation");
        }

        [Route("Confirmation")]
        public IActionResult Confirmation()
        {
            return this.View();
        }

        [Route("Admin")]
        public IActionResult Admin()
        {
            using (var connection = new SqlConnection(this.appSettings.Options.DataConnectionString))
            {
                return this.View(connection.Query<FormSubmission>("SELECT * FROM [FormSubmission]"));
            }
        }
    }
}