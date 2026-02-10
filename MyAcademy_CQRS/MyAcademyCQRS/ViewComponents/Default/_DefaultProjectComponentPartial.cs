using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Handlers.PhotoGalleryHandlers;

namespace MyAcademyCQRS.ViewComponents.Default
{
    public class _DefaultProjectComponentPartial(GetPhotoGalleryQueryHandler _handler) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _handler.Handle();
            return View(values);
        }
    }
}
