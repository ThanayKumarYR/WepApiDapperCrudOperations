

using BusinessLayer.Interface;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;

namespace BusinessLayer.Services
{
    public class EmployeeServiceBusinessLayer:IEmployeeBusinessLayer
    {
        private readonly IEmployeeRepositoryLayer employee;
        public EmployeeServiceBusinessLayer(IEmployeeRepositoryLayer employee) 
        {
            this.employee = employee;
        }
        public Task<IEnumerable<Employee>> GetEmployees()
        {
           return employee.GetEmployees();
        }
        public Task<Employee> GetEmployeeById(int empId)
        {
            return employee.GetEmployeeById(empId);
        }

    }
}
