using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using practicas.basefake;
using System.Security.Claims;

namespace practicas.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login (string username,string password)
        {
            var user = BaseFakeLogin.Users.FirstOrDefault(u => u.User == username && u.Password == password);
            if (user != null)
            {

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username)
                };

                 HttpContext.Session.SetString("User", user.User);

                 var identity = new ClaimsIdentity(claims, "cookies");
                 var principal = new ClaimsPrincipal(identity);

                HttpContext.SignInAsync("Cookies", principal);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = " Creedenciales Invalidas";
            }

                return View();
        }
        public IActionResult Logout() 
        {

			HttpContext.SignOutAsync("Cookies");
			return RedirectToAction("Login");
        
        }
    }
}
