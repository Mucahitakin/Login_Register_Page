using Microsoft.AspNetCore.Mvc;

namespace my_web_login.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Anasayfa()
        {
            return View();
        }
    }
}
