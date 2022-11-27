using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using inventory_360.Models;

namespace inventory_360.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<inventory_360.Models.Client> client { get; set; }
        public DbSet<inventory_360.Models.Employee> employee { get; set; }
        public DbSet<inventory_360.Models.Job> job { get; set; }
        public DbSet<inventory_360.Models.Equipment> equipment { get; set; }
    }
}

