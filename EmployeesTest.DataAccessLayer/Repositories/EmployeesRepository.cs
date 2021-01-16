using EmployeesTest.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesTest.DataAccessLayer.Repositories
{
  public class EmployeesRepository : Repository<Employee>
    {

        public EmployeesRepository(UnitOfWork uow) : base(uow) { }




    }
}
