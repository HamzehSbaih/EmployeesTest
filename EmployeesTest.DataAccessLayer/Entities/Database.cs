using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EmployeesTest.DataAccessLayer.Entities
{
    public partial class Database : DbContext
    {
        public Database()
            : base("name=Database")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
