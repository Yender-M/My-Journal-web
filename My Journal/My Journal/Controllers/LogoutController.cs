using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;


namespace My_Journal.Controllers
{
    public class LogoutController : Controller
    {
        // GET: /Logout
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //// Sign out the user
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //FormsAuthentication.SignOut();


            // Redirect to the login page or any other page after logout
            return RedirectToAction("Index", "Login");
        }
    }
}