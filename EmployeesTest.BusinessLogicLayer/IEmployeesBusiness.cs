using EmployeesTest.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesTest.BusinessLogicLayer
{
    public interface IEmployeesBusiness
    {
        bool CreateEmployee(EmployeesDTO employeeObj);
        bool DeleteEmployee(int employeeId);
        bool UpdateEmployee(EmployeesDTO employeeObj);
        EmployeesDTO GetEmployee(int EmployeeId);
        List<EmployeesDTO> GetEmployees();
    }
}
