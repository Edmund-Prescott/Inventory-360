using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace inventory_360.Models
{
    public class EditJobView
    {
        public int Id { get; set; } = 0;
        
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }
        [DisplayName("End Date")]
        public DateTime FinishDate { get; set; }
        [DisplayName("Equipment")]
        public List<Equipment>? Equipments { get; set; }
        [DisplayName("Employee")]
        public List<Employee>? Employees { get; set; }
        [DisplayName("Client")]
        public List<Client>? Clients { get; set; }
        public int SelectedEquipmentId { get; set; } = 0;
        public int SelectedEmployeeId { get; set; } = 0;
        public int SelectedClientId { get; set; } = 0;
    }
}
