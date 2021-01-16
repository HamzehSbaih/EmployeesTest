using EmployeesTest.Common.DTO;
using EmployeesTest.DataAccessLayer;
using EmployeesTest.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesTest.BusinessLogicLayer
{
    public class EmployeesBusiness : IEmployeesBusiness
    {
        public bool CreateEmployee(EmployeesDTO employeeObj)
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    uow.Employees.Create(Map(employeeObj));
                    uow.Save();
                    bool isAdded = true;

                    return isAdded;

                }
                catch (Exception ex)
                {
                    ex.Data.Add("CreatEmployee", "An error occurred while trying to create CreatEmployee Record - BLL");
                    uow.Rollback();

                    return false;
                }
            }
        }
        public bool UpdateEmployee(EmployeesDTO employeeObj)
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    uow.Employees.Update(Map(employeeObj));
                    uow.Save();
                    bool isUpdated = true;

                    return isUpdated;

                }
                catch (Exception ex)
                {
                    ex.Data.Add("UpdateEmployee", "An error occurred while trying to update UpdateEmployee Record - BLL");
                    uow.Rollback();

                    return false;
                }
            }
        }
        public bool DeleteEmployee(int employeeId)
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    Employee employee = new Employee();

                    employee = uow.Employees.GetById(employeeId);


                    uow.Employees.Delete(employee);
                    uow.Save();
                    bool isUpdated = true;

                    return isUpdated;

                }
                catch (Exception ex)
                {
                    ex.Data.Add(" DeleteEmployee", "An error occurred while trying to delete  DeleteEmployee Record - BLL");
                    uow.Rollback();

                    return false;
                }
            }
        }
        public EmployeesDTO GetEmployee(int EmployeeId)
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    EmployeesDTO dto = new EmployeesDTO();
                    dto = Map(uow.Employees.GetById(EmployeeId));



                    return dto;

                }
                catch (Exception ex)
                {
                    ex.Data.Add("GetEmployee", "An error occurred while trying to create GetEmployee Record - BLL");
                    uow.Rollback();

                    return null;
                }
            }
        }
        public List<EmployeesDTO> GetEmployees()
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    List<EmployeesDTO> dto = new List<EmployeesDTO>();
                    dto = Map(uow.Employees.GetAll().ToList());



                    return dto;

                }
                catch (Exception ex)
                {
                    ex.Data.Add("GetEmployee", "An error occurred while trying to create GetEmployee Record - BLL");
                    uow.Rollback();

                    return null;
                }
            }
        }
        public List<EmployeesDTO> Map(List<Employee> entities)
        {

            List<EmployeesDTO> employeesDTOs = new List<EmployeesDTO>();

            foreach (var entity in entities)
            {

                employeesDTOs.Add(new EmployeesDTO()
                {
                    Fname = entity.Fname,
                    Lname = entity.Lname,
                    Id = entity.Id,
                    fullname = entity.Fname + "   " + entity.Lname,
                });

            }
            return employeesDTOs;
        }
        public Employee Map(EmployeesDTO dto)
        {
            Employee entity = new Employee()
            {
                Fname = dto.Fname,
                Lname = dto.Lname,
                Id=dto.Id

            };



            return entity;
        }
        public EmployeesDTO Map(Employee entity)
        {
            EmployeesDTO dto = new EmployeesDTO();
            dto.Fname = entity.Fname;
            dto.Lname = entity.Lname;
            return dto;
        }
    }
}

