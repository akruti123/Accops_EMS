using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.Models
{

    [NotMapped]
    public class Employee : User
    {
        public Employee( Role role,String email, String password, string name, long phoneNumber, 
            DateTime joiningDate, string address, string city, string state, string zipcode, 
            string country,int departmentId) : base( email, password,role)
        {
           
            Email = email;
            Password = password;
            Name = name;
            PhoneNumber = phoneNumber;
            JoiningDate = joiningDate;
            Address = address;
            City = city;
            State = state;
            Zipcode = zipcode;
            Country = country;
            DepartmentId = departmentId;

        }
        public Employee()
        {
        }
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Phone Number is required")]
        public long PhoneNumber { get; set; }
        [Required(ErrorMessage = "JoiningDate is required")]
        public DateTime JoiningDate { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }
        [Required(ErrorMessage = "Zipcode is required")]
        public string Zipcode { get; set; }
        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }
        public int DepartmentId { get;  set; }

        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        public override string ToString()
        {
            return "Department Id: " + DepartmentId;
        }


    }
}
