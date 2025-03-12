using Microsoft.AspNetCore.Mvc;
using lab1.Models;

namespace lab1.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Details()
        {
            Student s1 = new Student
            {
                Id = 1,
                Name = "Bijay",
                Faculty = "Science"
            };
            return View(s1);
        }
    }
}
