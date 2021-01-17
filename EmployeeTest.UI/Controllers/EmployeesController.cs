using EmployeesTest.BusinessLogicLayer;
using EmployeesTest.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeTest.UI.Controllers
{
    public class EmployeesController : Controller
    {
        EmployeesBusiness _EmployeesBusiness = new EmployeesBusiness();
        // GET: Employees
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CreateEmployee()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CreateEmployee(EmployeesDTO dto)
        {
            bool isAdded = _EmployeesBusiness.CreateEmployee(dto);


            return RedirectToAction("GetEmployees");
        }
        [HttpGet]
        public ActionResult DeleteEmployee(int EmployeeId)
        {
            bool isDeleted = _EmployeesBusiness.DeleteEmployee(EmployeeId);

            return RedirectToAction("GetEmployees");
        }
        [HttpPost]
        public ActionResult UpdateEmployee(EmployeesDTO employeesDTO)
        {
            bool isUpdated = _EmployeesBusiness.UpdateEmployee(employeesDTO);
            //var employee = _EmployeesBusiness.GetEmployee(employeesDTO.Id);
            return RedirectToAction("GetEmployees");
        }
        [HttpGet]
        public ActionResult UpdateEmployee(int EmployeeId)
        {
            var employee = _EmployeesBusiness.GetEmployee(EmployeeId);
            return View(employee);
        }
        public ActionResult GetEmployee(int EmployeeId)
        {
            var employee = new EmployeesDTO();
            employee = _EmployeesBusiness.GetEmployee(EmployeeId);
            return View(employee);
        }
        public ActionResult GetEmployees()
        {
            var employees = new List<EmployeesDTO>();
            employees = _EmployeesBusiness.GetEmployees();
            return View(employees);
        }



    }
}