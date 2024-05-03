using Dapper;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;

namespace RepositoryLayer.Services
{
    public class EmployeeServiceRepositoryLayer : IEmployeeRepositoryLayer
    {
        private readonly DapperContext _context;

        public EmployeeServiceRepositoryLayer(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var query = "SELECT * FROM Employee";
            using (var connection = _context.CreateConnection())
            { 
                var employee = await connection.QueryAsync<Employee>(query);
                return employee.ToList();
            }
        }

        public async Task<Employee> GetEmployeeById(int empId)
        {
            var query = "SELECT * FROM Employee where Id = @empId";
            using (var connection = _context.CreateConnection())
            {
                var employee = await connection.QueryFirstOrDefaultAsync<Employee>(query, new {empId});
                return employee;
            }

        }
    }
}
