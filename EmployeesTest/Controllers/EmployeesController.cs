using EmployeesTest.BusinessLogicLayer;
using EmployeesTest.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace EmployeesTest.Controllers
{

    [System.Web.Http.RoutePrefix("api/Employees")]
    public class EmployeesController : ApiController
    {
        EmployeesBusiness _EmployeesBusiness = new EmployeesBusiness();

        public EmployeesController()
        {

        }
        // GET: Employees
        public IHttpActionResult Index()
        {
            return Ok();
        }

        [System.Web.Http.Route("CreateEmployee")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateEmployee(EmployeesDTO dto)
        {
            bool isAdded = _EmployeesBusiness.CreateEmployee(dto);


            return Ok(isAdded);
        }
        [System.Web.Http.Route("DeleteEmployee")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult DeleteEmployee(int EmployeeId)
        {
            bool isDeleted = _EmployeesBusiness.DeleteEmployee(EmployeeId);

            return Ok(isDeleted);
        }
        [System.Web.Http.Route("UpdateEmployee")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult UpdateEmployee(EmployeesDTO employeesDTO)
        {
            bool isUpdated = _EmployeesBusiness.UpdateEmployee(employeesDTO);
            return Ok(isUpdated);
        }
        [System.Web.Http.Route("GetEmployee")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetEmployee(int EmployeeId)
        {
            var employee = new EmployeesDTO();
            employee = _EmployeesBusiness.GetEmployee(EmployeeId);
            return Ok(employee);
        }
        [System.Web.Http.Route("GetEmployees")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetEmployees()
        {
            var employees = new List<EmployeesDTO>();
            employees = _EmployeesBusiness.GetEmployees();
            return Ok(employees);
        }


    }
}