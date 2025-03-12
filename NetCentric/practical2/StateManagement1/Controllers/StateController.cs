using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StateManagement1.Controllers
{
    public class StateController : Controller
    {
        public IActionResult SetSession()
        {
            HttpContext.Session.SetString("User", "bijay");
            TempData["Message"] = "Session value has been set!";
            return RedirectToAction("GetSession");
        }

        public IActionResult GetSession()
        {
            string user = HttpContext.Session.GetString("User");
            ViewBag.User = user ?? "No session found!";
            ViewBag.Message = TempData["Message"];

            return View("SessionView");
        }
        public IActionResult TempDataDemo()
        {

            ViewData["data1"] = "this is data from view data (Bijay)";
            ViewBag.data2 = "this is data from view bag (CSIT)";
            TempData["data3"] = "data from temp data (ktm, teku)";
            return View();
        }
    }
}