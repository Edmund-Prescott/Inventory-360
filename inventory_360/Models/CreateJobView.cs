using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace inventory_360.Models
{
    public class CreateJobView
    {
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }
        [DisplayName("End Date")]
        public DateTime FinishDate { get; set; }
        public List<Equipment>? Equipments { get; set; }
        public List<Employee>? Employees { get; set; }
        public List<Client>? Clients { get; set; }
        public int SelectedEquipmentId { get; set; } = 0;
        public int SelectedEmployeeId { get; set; } = 0;
        public int SelectedClientId { get; set; } = 0;

    }
}
