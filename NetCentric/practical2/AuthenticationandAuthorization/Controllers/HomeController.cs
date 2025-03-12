using System.Diagnostics;
using AuthenticationandAuthorization.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AuthenticationandAuthorization.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        //to be authorize a person should be authenticate first
        //for authentication and authorization cookie is used as unique identifier
        //step1: create controller and use annotatio[authorize]
        //steo2: add authentication mechanism(cookie) in program.cs
        //step3: make user to login first if login success then make authorize
        [Authorize]
        public IActionResult Dashboard() 
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Contact()
        {
            return View();
        }
        //creating login controller for authentication
        [HttpGet]
        public IActionResult Login(String returnUrl)
        {
            //send url to view for this we will use view data
            ViewData["returnUrl"] = returnUrl;
            return View();
        }
        //creating login action method with Post annotation 
        //checking authentication : username, password if match add authorize
        [HttpPost]
        public IActionResult Login(string uname, string pass, string ReturnUrl) {
            if(uname =="ram"&& pass =="ram")
            {
                //add authorization: claim, claimIdentity,claimPrinciple
                //claim: detail of authorization.
                //which identifier to be used
                List<Claim> cl = new List<Claim>();
                cl.Add(new Claim(ClaimTypes.NameIdentifier, uname));
                cl.Add(new Claim(ClaimTypes.Name, uname));
                //for roles admin : add role
                cl.Add(new Claim(ClaimTypes.Role, "Admin"));
                //claim identity: how to authorize(Token or cookie)
                ClaimsIdentity ci = new ClaimsIdentity(cl,CookieAuthenticationDefaults.AuthenticationScheme);
                //claim principles: whom to authorize
                ClaimsPrincipal cp = new ClaimsPrincipal(ci);   
                //executing authorization mechanism
                HttpContext.SignInAsync(cp);
                return Redirect(ReturnUrl);
            }
            return View();
          }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
