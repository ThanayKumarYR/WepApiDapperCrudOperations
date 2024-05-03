using BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;

namespace CURD_With_Dapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeBusinessLayer _employee;
        public EmployeeController(IEmployeeBusinessLayer employee)
        {
            this._employee = employee;
        }

        [HttpGet("GetEmployeeList")]
        public async Task<IActionResult> GetEmployeeList()
        {
            try
            {
                var employee = await _employee.GetEmployees();
                return Ok(employee);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("empId={employeeId}", Name = "GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeById(int employeeId)
        {
            try
            {
                var employee = await _employee.GetEmployeeById(employeeId);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("empName={employeeName}", Name = "GetEmployeeByName")]
        public async Task<IActionResult> GetEmployeeByName(string employeeName)
        {
            try
            {
                var employee = await _employee.GetEmployeeByName(employeeName);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("search={employeeNameLikeCharacters}", Name = "SearchEmployeeByNameLikeCharacters")]
        public async Task<IActionResult> SearchEmployeeByNameLikeCharacters(string employeeNameLikeCharacters)
        {
            try
            {
                var employee = await _employee.SearchEmployeeByNameLikeCharacters(employeeNameLikeCharacters);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("CreateEmployee")]
        public async Task<IActionResult> CreateEmployee(Employee employee)
        {
            try
            {
                var insertedEmployee = await _employee.AddEmployeeAsync(employee);
                return Ok(insertedEmployee);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

    }
}
