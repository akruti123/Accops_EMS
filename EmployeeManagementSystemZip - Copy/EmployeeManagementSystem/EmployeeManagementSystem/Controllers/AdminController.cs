using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.DBMethods;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmployeeManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly Finder _finder;
        const string SessionName = "_Name";
        const string SessionRole = "_Role";
        const string SessionId = "_Id";
        public AdminController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
              
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult AdminHomePage()
        {
            //
            ViewBag.sess_user_name = HttpContext.Session.GetString(SessionName);
            IEnumerable<User> users = _db.Users;
            Console.WriteLine("Helloooooooooooo");
            return View(users);
        }

        //Get
        public IActionResult Create()
        {
            List<Department> depList = _db.Departments.ToList();
            ViewBag.Deps = depList;
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee e1)
        {
            var data = _db.Users.Where(u=>u.Email == e1.Email).FirstOrDefault();
            if (data == null)
            {
                _db.Employees.Add(e1);
                Console.WriteLine(e1.ToString());
                _db.SaveChanges();
                return RedirectToAction("AdminHomePage");
            }
            else
            {
                TempData["error"] = "Email Already Exists try another email";
                List<Department> depList = _db.Departments.ToList();
                ViewBag.Deps = depList;
                return View();
            }
                
        }
        //Get
        public IActionResult AddDepartment()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddDepartment(Department d1)
        {
            var data = _db.Departments.Where(d => d.DepartmentName == d1.DepartmentName).FirstOrDefault();
            if (data == null)
            {
                _db.Departments.Add(d1);
                _db.SaveChanges();
                return RedirectToAction("AdminHomePage");
            }
            else
                TempData["error"] = "Department Already Exists";
                return View();
            
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
            return RedirectToAction("AdminHomePage");
        }
        //Get
        public IActionResult Delete(int? id)
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Employees.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Employees.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("AdminHomePage");

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
        public ActionResult PartialViewForEdit(int? id)
        {
            Employee emp = _db.Employees.Find(id);
            var sess_role = HttpContext.Session.GetString(SessionRole);
            if (sess_role.Equals("ADMIN"))
            {
                Console.WriteLine("==============================================" + sess_role);
                return RedirectToAction("AdminHomePage");
               
            }
            return RedirectToAction("EmployeeHomePage","Employee", emp);
        }


    }
}