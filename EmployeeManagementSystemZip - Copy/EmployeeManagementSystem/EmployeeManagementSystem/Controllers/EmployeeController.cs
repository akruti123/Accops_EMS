using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.DBMethods;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _db;
        const string SessionName = "_Name";
        const string SessionRole = "_Role";
        const string SessionId = "_Id";
        private readonly Finder _finder;
        public EmployeeController(ApplicationDbContext db)
        {
            _finder = new Finder(db);
            _db=db;
        }
        public IActionResult Index()
        {
            return RedirectToAction("Login");

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //get
        public IActionResult EmployeeHomePage(Employee emp)
        {

            ViewBag.sess_user_name = HttpContext.Session.GetString(SessionName);
            var employee = _finder.FindEmployeeById(emp.UserId);
            Department department = _finder.FindDepartmentById(emp.DepartmentId);
            String depName = department.DepartmentName;
            ViewBag.dep = depName;
            ViewBag.userId = emp.UserId;
            Console.WriteLine("+++++++++++++++++++" + emp.UserId);
            return View(emp);
        }

        //Get
        public IActionResult Edit(int? id)
        {
            List<Department> depList = _db.Departments.ToList();
            ViewBag.Deps = depList;
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var employeeFromDb = _db.Employees.Find(id);

            if (employeeFromDb == null)
            {
                return NotFound();
            }

            return View(employeeFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee obj)
        {
            _db.Employees.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("EmployeeHomePage", "Employee", obj);
        }

    }
}