using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Entity
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        
        public Employee() { }

        public Employee(Employee employee)
        { 
            this.Id = employee.Id;
            this.Name = employee.Name;
            this.Age = employee.Age;
            this.Position = employee.Position;
        }
    }
}
