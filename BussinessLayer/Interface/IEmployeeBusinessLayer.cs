using RepositoryLayer.Entity;

//Businness Layer acts as a interface between Data Access Layer and Presentation Layer 
namespace BusinessLayer.Interface
{
    public interface IEmployeeBusinessLayer
    {
        
        public Task<IEnumerable<Employee>> GetEmployees();
        public Task<Employee> GetEmployeeById(int empId);
        public Task<Employee> GetEmployeeByName(string empName);
        public Task<IEnumerable<Employee>> SearchEmployeeByNameLikeCharacters(string empNameLikeCharacters);
    }
}
