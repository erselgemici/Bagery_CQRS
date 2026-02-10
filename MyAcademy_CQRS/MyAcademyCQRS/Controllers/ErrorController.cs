using Microsoft.AspNetCore.Mvc;

namespace MyAcademyCQRS.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult NotFound404()
        {
            return View();
        }
    }
}
