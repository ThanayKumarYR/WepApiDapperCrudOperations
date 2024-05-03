using Azure;
using Dapper;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System.Data;

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
        public async Task<Employee> GetEmployeeByName(string empName)
        {
            var query = "exec spGetEmployeeByName @empName";
            using (var connection = _context.CreateConnection())
            {
                var employee = await connection.QueryFirstOrDefaultAsync<Employee>(query, new { empName });
                return employee;
            }

        }
        public async Task<IEnumerable<Employee>> SearchEmployeeByNameLikeCharacters(string empNameLikeCharacters)
        {
            var query = "exec spGetEmployeeByNameLikeCharacters @empNameLikeCharacters";
            using (var connection = _context.CreateConnection())
            {
                var employee = await connection.QueryAsync<Employee>(query,new { empNameLikeCharacters });
                return employee.ToList();
            }
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            const string insertQuery = @"INSERT INTO Employee (Id, Name, Age, Position) VALUES (@Id, @Name, @Age, @Position)";
            const string selectQuery = @"SELECT * FROM Employee WHERE Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                // Execute the INSERT statement
                await connection.ExecuteAsync(insertQuery, employee);

                // Fetch the inserted employee using the SELECT statement
                var insertedEmployee = await connection.QueryFirstOrDefaultAsync<Employee>(selectQuery, new { employee.Id });

                return insertedEmployee;
            }
        }

    }
}
