using RepositoryLayer.Entity;

namespace RepositoryLayer.Interface
{
    public interface IEmployeeRepositoryLayer
    {
        //Repository layer interface used for Data Access.
        public Task<IEnumerable<Employee>> GetEmployees();
        public Task<Employee> GetEmployeeById(int empId);
        public Task<Employee> GetEmployeeByName(string empName);
        public Task<IEnumerable<Employee>> SearchEmployeeByNameLikeCharacters(string empNameLikeCharacters);
    }
}
