using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using instrumentRentals2.Models;

namespace instrumentRentals2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<instrumentRentals2.Models.instrument> instrument { get; set; }
        public DbSet<instrumentRentals2.Models.customer> customer { get; set; }
        public DbSet<instrumentRentals2.Models.rentalAgreement> rentalAgreement { get; set; }
    }
}

