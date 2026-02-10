using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Handlers.ProductHandlers;
using System.Threading.Tasks;

namespace MyAcademyCQRS.ViewComponents.Shop
{
    public class _ShopProductListComponentPartial(GetProductQueryHandler _getProductQueryHandler) : ViewComponent
    {      

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _getProductQueryHandler.Handle();
            return View(values);
        }
    }
}
