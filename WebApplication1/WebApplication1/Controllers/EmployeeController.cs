using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Core.Interface;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IEmployee _context;
        public EmployeeController(IEmployee _context)
        {
            this._context = _context;
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployee()
        {
            try
            {
                var result = _context.GetEmployee();
                log.Info("Data is Displayed");
                return StatusCode(200, result);
            }
            catch (Exception)
            {
                log.Error("Error Occured");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retrieving Data from the DataBase");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeModel employeeModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _context.AddEmployee(employeeModel);
                    log.Error("Created Successfully");
                    return StatusCode(200, "Created Successfully");
                }
                else
                {
                    log.Error("No Data");
                    return BadRequest("No Data");
                }
            }
            catch (Exception)
            {
                log.Error("Error Occur");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Adding Data to the DataBase");
            }
        }
        [HttpPut("{id:int")]
        public async Task<IActionResult> UpdateEmployee(EmployeeModel employeeModel)
        {
            try
            {
                var result = _context.UpdateEmployee(employeeModel);
                log.Error("Updated Successfully");
                return StatusCode(200, "Updated Successfully");
            }
            catch (Exception)
            {
                log.Error("Error Occur");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating Data to the Database");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var result = _context.DeleteEmployee(id);
                log.Error("Deleted Successfully");
                return StatusCode(200, "Deleted Successfully");
            }
            catch (Exception)
            {
                log.Error("Error occur");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating Data to the Database");
            }
        }
    }
}
