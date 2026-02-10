using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Handlers.TestimonialHandlers;

namespace MyAcademyCQRS.ViewComponents.Default
{
    public class _DefaultTestimonialComponentPartial(GetTestimonialQueryHandler _handler) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _handler.Handle();
            return View(values);
        }
    }
}
