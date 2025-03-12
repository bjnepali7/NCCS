using Microsoft.AspNetCore.Mvc;

namespace StateManagement1.Controllers
{
    public class StateControllerDemo : Controller
    {
       
        // Set Cookie
        public IActionResult SetCookie()
        {
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddMinutes(10); // Cookie expires in 10 minutes

            Response.Cookies.Append("UserName", "Bijay", option);
            ViewBag.Message = "Cookie has been set!";
            return View("ClientStateView");
        }

        // Get Cookie
        public IActionResult GetCookie()
        {
            string userName = Request.Cookies["UserName"];
            ViewBag.Message = userName ?? "No cookie found!";
            return View("ClientStateView");
        }
        public IActionResult QueryStringExample(string name, int age)
        {
            ViewBag.Message = $"Name: {name}, Age: {age}";
            return View("ClientStateView");
        }
        [HttpPost]
        public IActionResult SubmitHidden(string HiddenData)
        {
            ViewBag.Message = "Hidden Field Value: " + HiddenData;
            return View("ClientStateView");
        }

    }
}
