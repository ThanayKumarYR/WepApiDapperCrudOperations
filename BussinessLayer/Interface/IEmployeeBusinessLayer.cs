using RepositoryLayer.Entity;

namespace BusinessLayer.Interface
{
    public interface IEmployeeBusinessLayer
    {
        public Task<IEnumerable<Employee>> GetEmployees();
        public Task<Employee> GetEmployeeById(int empId);
    }
}
