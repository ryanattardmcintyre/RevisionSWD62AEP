using Common.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Models.ViewModels
{
    public class CreateEmployeeViewModel
    {
        public string Name { get; set; }
        public string DepartmentFk { get; set; }
        
        public string PassportNo { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
