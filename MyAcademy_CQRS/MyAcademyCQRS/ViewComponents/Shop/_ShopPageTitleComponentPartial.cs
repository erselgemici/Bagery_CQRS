using Microsoft.AspNetCore.Mvc;

namespace MyAcademyCQRS.ViewComponents.Shop
{
    public class _ShopPageTitleComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
