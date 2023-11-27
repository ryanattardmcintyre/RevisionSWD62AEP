using Common.Interfaces;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class EmployeeFileRepository : IEmployeesRepository
    {
        private string _path;
        public EmployeeFileRepository(string path) { _path = path;
        
        if(!File.Exists(path))
                using (var file =File.Create(path))
                {
                    file.Close();
                }
        
        }

        public void AddEmployee(Employee e)
        {
            var list = GetEmployees().ToList();

            bool found = false;
            int proposedId = list.Count;
            do
            {
                if (list.SingleOrDefault(x => x.ID == proposedId) == null)
                    found = false;
                else
                {
                    found = true; proposedId++;
                }
            } while (found==true);

            e.ID = proposedId;

            list.Add(e);

            string contents = JsonSerializer.Serialize(list);

            File.WriteAllText(_path, contents);
        }

        public IQueryable<Employee> GetEmployees()
        {

            string contents = File.ReadAllText(_path);
            if (string.IsNullOrEmpty(contents))
            {
                return new List<Employee>().AsQueryable();
            }
            try
            {
                var list = JsonSerializer.Deserialize<List<Employee>>(contents);
                return list.AsQueryable();
            }
            catch (Exception ex)
            {
                throw new Exception("Badly formatted data was read");
            }
        }
    }
}
