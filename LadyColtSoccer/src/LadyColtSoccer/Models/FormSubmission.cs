// <author>
//   Tony Morris
// </author>
// <modified>
//   2015-08-29 10:57 PM
// </modified>
// <created>
//   2015-08-29 9:24 PM
// </created>

namespace LadyColtSoccer.Models
{
    using System;

    public class FormSubmission
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public NumberOfTickets NumberOfTickets { get; set; }

        public string ContactChoice { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public string AdditionalInformation { get; set; }

        public DateTime DateEntered { get; set; }
    }
}