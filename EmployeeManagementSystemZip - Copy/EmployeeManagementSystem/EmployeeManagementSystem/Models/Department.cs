using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.Models
{
    //[Table("departments")]
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Department Name is Required")]
        public string DepartmentName { get; set; }
        //public List<Employee> EmployeeList=new List<Employee>();
        public Department()
        { 
        }
        public Department(int departmentId, string departmentName)
        {
            DepartmentId = departmentId;
            DepartmentName = departmentName;
            //EmployeeList = employeeList;    
        }
        
    }
}
