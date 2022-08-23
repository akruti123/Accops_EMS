using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmployeeManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        const string SessionName = "_Name";
        const string SessionRole = "_Role";
        const string SessionId = "_Id";
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
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


        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {

            if (ModelState.IsValid)
            {
                var data = _db.Users.Where(u => u.Email.Equals(email) && u.Password.Equals(password)).ToList();
                if (data.Count == 0)
                {
                    TempData["error"] = "Login failed, Invalid email or password";
                    return RedirectToAction("Login");
                }

                String role = data[0].Role.ToString();
                Employee e = _db.Employees.Find(data[0].UserId);
                HttpContext.Session.SetString(SessionName, e.Name);
                Console.WriteLine("Data====" + data[0].Role.ToString());
                HttpContext.Session.SetString(SessionRole, data[0].Role.ToString());
                HttpContext.Session.SetInt32(SessionId, data[0].UserId);
                Console.WriteLine("==============================================" + HttpContext.Session.GetString(SessionRole));
                if (data.Count == 1 && role.Equals("ADMIN"))
                {
                    return RedirectToAction("AdminHomePage", "Admin");
                }
                else if (data.Count == 1 && role.Equals("EMPLOYEE"))
                {
                    int employeeId = data[0].UserId;
                    Employee emp = _db.Employees.Find(employeeId);
                    Console.WriteLine("-------------------" + employeeId);
                    return RedirectToAction("EmployeeHomePage","Employee", emp);
                }
                
            }
            return View();
        }
        //Get
        public IActionResult ViewEmployeeDetails(int? id)
        {
            var employee = _db.Employees.Find(id);
            Department department = _db.Departments.Find(employee.DepartmentId);
            String depName = department.DepartmentName;
            ViewBag.sess_user_name = HttpContext.Session.GetString(SessionName);
            ViewBag.dep = depName;
            return View(employee);
        }

        public ActionResult Logout()
        {
            try
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login");
            }
            catch
            {
                throw;
            }
        }

    }
}