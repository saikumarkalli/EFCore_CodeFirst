using AF_EF.Models;
using EFCore_CodeFirst.Context;
using EFCore_CodeFirst.Services.EmployeeService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore_CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        DataContext dataContext = new DataContext();

        private readonly IEmployeeService _employeeService;
        public UserController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        //GetAll
        [HttpGet("GetData")]
        public async Task<IActionResult> GetData()
        {
            try
            {
                var data = await _employeeService.GetData();

                if (data.Count <= 0)
                    return NotFound();

                return Ok(data);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //GetByID
        [HttpGet("GetByID")]
        public async Task<IActionResult> GetByID(int id)
        {
            try
            {
                if (id != 0)
                {
                    //SQL
                    var data = await _employeeService.GetDataById(id);

                    if (data == null)
                        return NotFound();

                    return Ok(data);
                }
                else return BadRequest();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Insert
        [HttpPost("InsertEmployee")]
        public async Task<IActionResult> InsertEmployee([FromBody] Employee employee)
        {
            try
            {
                var data = await _employeeService.InsertEmployee(employee);

                if (data.Equals(true))
                    return Ok(data);
                else
                    return BadRequest(data);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Update
        [HttpPut("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee([FromBody] Employee employee)
        {
            try
            {
                var data = await _employeeService.UpdateEmployee(employee);

                if (data.Equals(true))
                    return Ok(data);
                else
                    return BadRequest(data);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Delete
        [HttpDelete("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var data = await _employeeService.DeleteEmployee(id);

                if (data.Equals(true))
                    return Ok(data);
                else
                    return BadRequest(data);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
