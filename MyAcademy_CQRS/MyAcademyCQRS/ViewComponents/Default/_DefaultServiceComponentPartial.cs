using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Handlers.ServiceHandlers;

namespace MyAcademyCQRS.ViewComponents.Default
{
    public class _DefaultServiceComponentPartial(GetServiceQueryHandler _handler) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _handler.Handle();
            return View(values);
        }
    }
}
