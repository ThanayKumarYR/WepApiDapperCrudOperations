using RepositoryLayer.Entity;

namespace RepositoryLayer.Interface
{
    public interface IEmployeeRepositoryLayer
    {
        public Task<IEnumerable<Employee>> GetEmployees();
        public Task<Employee> GetEmployeeById(int empId);
    }
}
