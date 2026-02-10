using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Handlers.NewsHandlers;

namespace MyAcademyCQRS.ViewComponents.Default
{
    public class _DefaultNewsComponentPartial(GetNewsQueryHandler _handler) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _handler.Handle();
            return View(values);
        }
    }
}
