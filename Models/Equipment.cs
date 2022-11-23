using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_360.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Make { get; set; }
        public int Model { get; set; }
        public Employee Employee { get; set; }
    }
}
