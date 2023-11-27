using Common.Interfaces;
using Common.Models;
using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class EmployeeDbRepository: IEmployeesRepository
    {
        private EmployeeDbContext _db;
        public EmployeeDbRepository(EmployeeDbContext employeeDb) { 
        _db = employeeDb;
        }

        public void AddEmployee(Employee e)
        { 
          _db.Employees.Add(e); 
            _db.SaveChanges();
        }

        public IQueryable<Employee> GetEmployees()
        {
            return _db.Employees;
        }
    }
}
