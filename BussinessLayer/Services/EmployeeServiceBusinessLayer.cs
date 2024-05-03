

using BusinessLayer.Interface;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;

namespace BusinessLayer.Services
{
    public class EmployeeServiceBusinessLayer:IEmployeeBusinessLayer
    {
        private readonly IEmployeeRepositoryLayer _employee;
        public EmployeeServiceBusinessLayer(IEmployeeRepositoryLayer employee) 
        {
            this._employee = employee;
        }
        public Task<IEnumerable<Employee>> GetEmployees()
        {
           return _employee.GetEmployees();
        }
        public Task<Employee> GetEmployeeById(int empId)
        {
            return _employee.GetEmployeeById(empId);
        }
        public Task<Employee> GetEmployeeByName(string empName)
        {
            return _employee.GetEmployeeByName(empName);
        }
        public Task<IEnumerable<Employee>> SearchEmployeeByNameLikeCharacters(string empNameLikeCharacters)
        {
            return _employee.SearchEmployeeByNameLikeCharacters(empNameLikeCharacters);
        }

        public Task<Employee> AddEmployeeAsync(Employee employee)
        {
            return _employee.AddEmployeeAsync(employee);
        }
    }
}
