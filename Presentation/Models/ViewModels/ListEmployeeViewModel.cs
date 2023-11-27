using System.ComponentModel.DataAnnotations.Schema;

namespace Presentation.Models.ViewModels
{
    public class ListEmployeeViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string DepartmentName { get; set; }
    }
}
