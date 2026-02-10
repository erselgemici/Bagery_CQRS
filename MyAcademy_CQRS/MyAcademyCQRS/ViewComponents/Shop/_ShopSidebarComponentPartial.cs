using Microsoft.AspNetCore.Mvc;

namespace MyAcademyCQRS.ViewComponents.Shop
{
    public class _ShopSidebarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
