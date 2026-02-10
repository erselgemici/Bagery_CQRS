using Microsoft.AspNetCore.Mvc;

namespace MyAcademyCQRS.Controllers
{
    public class ShopController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

    }
}
