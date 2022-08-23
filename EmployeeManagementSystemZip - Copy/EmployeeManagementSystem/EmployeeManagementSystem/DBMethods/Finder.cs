using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
namespace EmployeeManagementSystem.DBMethods
{
    public class Finder
    {
        private readonly ApplicationDbContext _db;
        public Finder(ApplicationDbContext db)
        {
            _db = db;
        }
        public User FindUserById(int id)
        {
            User u = _db.Users.Find(id);
            return u;   
        }
        public Employee FindEmployeeById(int id)
        {
            Employee e = _db.Employees.Find(id);
            return e;
        }
        public Department FindDepartmentById(int id)
        {
            Department d = _db.Departments.Find(id);
            return d;
        }
    }
}
