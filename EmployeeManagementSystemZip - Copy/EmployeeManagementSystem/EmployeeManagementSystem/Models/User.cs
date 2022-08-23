using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.Models
{
    
    public class User
    {
        [Key]
        [Column("user_id")]
        public int UserId { get; set; }

        [Column("email"), Required(ErrorMessage = "Email Id is Required")]
        public string Email{ get; set; }

        [MinLength(3)]
        [Column("password"), Required(ErrorMessage = "Password is Required"),DataType(DataType.Password)]
        public string Password{ get; set; }

        [Required(ErrorMessage = "Role is Required")]
        [Column(TypeName = "nvarchar(20)")]
        public Role Role{ get; set; }
        public User(string email,string password,Role role)
        {

            Role = role;
            Email = email;
            Password = password;
        }
        public User()
        { }
        public override String ToString()
        {
            return "UserId===============" + UserId;
        }
    }
}
