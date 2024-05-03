using BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("{employeeId}",Name = "GetEmployeeById")]
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

    }
}
