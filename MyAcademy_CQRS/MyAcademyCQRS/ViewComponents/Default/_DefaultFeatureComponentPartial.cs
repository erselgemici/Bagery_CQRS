using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Handlers.FeatureHandlers;

namespace MyAcademyCQRS.ViewComponents.Default
{
    public class _DefaultFeatureComponentPartial(GetFeatureQueryHandler _handler) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _handler.Handle(); 
            return View(values);
        }
    }
}
