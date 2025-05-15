using LoginApp.Models;
using LoginApp.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: AccountController
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(User user)
        {
            if (_userService.IsEmailTaken(user.Email))
            {
                ViewBag.Message = "Email already exists!";
                return View();
            }

            _userService.RegisterUser(user);
            ViewBag.Message = "Signup successful!";
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var user = _userService.Authenticate(email, password);
            if (user != null)
            {
                HttpContext.Session.SetInt32("UserId", user.UserId);
                TempData["Success"] = "Welcome " + user.Name;
                return RedirectToAction("Dashboard");
            }

            ViewBag.Error = "Invalid credentials.";
            return View();
        }

        public ActionResult Dashboard()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) return RedirectToAction("Login");

            var user = _userService.GetUser(userId.Value);
            ViewBag.User = user;
            ViewBag.Message = TempData["Success"];
            ViewData["LoginTime"] = DateTime.Now.ToString();

            return View();
        }

        [HttpPost]
        public JsonResult CheckEmail(string email)
        {
            return Json(!_userService.IsEmailTaken(email));
        }
    }
}
