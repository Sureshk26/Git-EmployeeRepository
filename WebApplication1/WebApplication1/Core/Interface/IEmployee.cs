using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Core.Interface
{
    public interface IEmployee
    {
        List<EmployeeModel> GetEmployee();
        EmployeeModel AddEmployee(EmployeeModel employeeModel);
        EmployeeModel UpdateEmployee(EmployeeModel employeeModel);
        EmployeeModel DeleteEmployee(int employeeId);
    }
}
