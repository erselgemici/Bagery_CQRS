using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Handlers.SliderHandlers;

namespace MyAcademyCQRS.ViewComponents.Default
{
    public class _DefaultSliderComponentPartial(GetSliderQueryHandler _handler) : ViewComponent
    {      

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _handler.Handle();
            return View(values);
        }
    }
}
