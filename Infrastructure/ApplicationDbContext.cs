using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext ( DbContextOptions<ApplicationDbContext> options ) : base(options)
        {
        }

        public DbSet<TaxPayer> TaxPayers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Obligation> Obligations { get; set; }
        public DbSet<BusinessApplication> BusinessApplications { get; set; }
        public DbSet<Advisor> Advisors { get; set; }
    }
}
