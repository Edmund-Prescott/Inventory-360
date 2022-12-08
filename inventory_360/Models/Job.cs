using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventory_360.Models
{
    public class Job
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public Equipment Equpiment { get; set; }
        public Employee Employee { get; set; }
        public Client Client { get; set; }

        public List<Equipment>? Equipments { get; set; }
        public List<Employee>? Employees { get; set; }
        public List<Client>? Clients { get; set; }
        public Job()
        {
            Equpiment = new Equipment();
            Employee = new Employee();
            Client = new Client();
        }
    }
}
