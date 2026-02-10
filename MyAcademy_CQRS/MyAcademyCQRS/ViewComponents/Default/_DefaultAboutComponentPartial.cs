using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Handlers.AboutHandlers;

namespace MyAcademyCQRS.ViewComponents.Default
{
    public class _DefaultAboutComponentPartial(GetAboutQueryHandler _handler) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _handler.Handle();
            return View(values);
        }
    }
}
