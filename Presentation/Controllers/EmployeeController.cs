using Common.Interfaces;
using Common.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models.ViewModels;

namespace Presentation.Controllers
{
    public class EmployeeController : Controller
    {

        private IEmployeesRepository employeeDbRepository;
        public EmployeeController(IEmployeesRepository empRepo ) { 
        
        employeeDbRepository = empRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SearchEmployee(string keyword)
        {
            var list = employeeDbRepository.GetEmployees().Where(x => x.Name.Contains(keyword));
            var resultList = from employee in list
                             select new ListEmployeeViewModel()
                             {
                                 ID = employee.ID,
                                 DepartmentName = employee.Department.Name,
                                 Name = employee.Name
                             };

            return View(resultList);
        
        }



        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(CreateEmployeeViewModel emp) { 
        
            var empFound = employeeDbRepository.GetEmployees().SingleOrDefault(x=>x.PassportNo == emp.PassportNo);
            if (empFound == null)
            {
                //no employee was found
                employeeDbRepository.AddEmployee(new Employee()
                {
                    PassportNo = emp.PassportNo,
                    DepartmentFk = emp.DepartmentFk,
                    Name = emp.Name,
                    Password = emp.Password,
                    Username = emp.Username

                });
            }
            else
            {
                throw new Exception("Employee already exists");
            }

            return View(emp);
        
        
        }
    }
}
