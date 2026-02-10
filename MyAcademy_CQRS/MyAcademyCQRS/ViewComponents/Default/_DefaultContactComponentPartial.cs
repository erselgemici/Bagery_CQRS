using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Handlers.ContactInfoHandlers;

namespace MyAcademyCQRS.ViewComponents.Default
{
    public class _DefaultContactComponentPartial(GetContactInfoQueryHandler _handler) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _handler.Handle();
            return View(values);
        }
    }
}
