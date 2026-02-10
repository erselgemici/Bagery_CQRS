using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Handlers.ProductHandlers;

namespace MyAcademyCQRS.ViewComponents.Default
{
    public class _DefaultProductComponentPartial(GetProductQueryHandler _handler) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _handler.Handle();
            return View(values);
        }
    }
}
