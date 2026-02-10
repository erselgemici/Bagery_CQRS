using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Handlers.PromotionHandlers;

namespace MyAcademyCQRS.ViewComponents.Default
{
    public class _DefaultPromotionComponentPartial(GetPromotionQueryHandler _handler) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _handler.Handle();
            return View(values);
        }
    }
}
