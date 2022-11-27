using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using inventory_360.Models;

namespace inventory_360.Data
{
    public class inventory_360Context : DbContext
    {
        public inventory_360Context (DbContextOptions<inventory_360Context> options)
            : base(options)
        {
        }

        public DbSet<inventory_360.Models.Client> Client { get; set; }

        public DbSet<inventory_360.Models.Employee> Employee { get; set; }

        public DbSet<inventory_360.Models.Equipment> Equipment { get; set; }

        public DbSet<inventory_360.Models.Job> Job { get; set; }

        public DbSet<inventory_360.Models.ErrorViewModel> ErrorViewModel { get; set; }
    }
}
