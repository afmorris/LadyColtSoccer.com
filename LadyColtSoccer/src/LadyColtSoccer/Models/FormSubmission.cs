using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LadyColtSoccer.Models
{
    using Microsoft.Data.Entity;

    public class FormSubmission
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public NumberOfTickets NumberOfTickets { get; set; }
        public string ContactChoice { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string AdditionalInformation { get; set; }
    }

    public class FormContext : DbContext
    {
        public DbSet<FormSubmission> Submissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ForSqlServer().UseIdentity();
        }
    }
}
