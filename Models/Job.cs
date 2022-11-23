using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_360.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string JobNumber { get; set; }
        public int StartDate { get; set; }
        public int FinishDate { get; set; }
        public Equipment Equpiment { get; set; }
    }
}
