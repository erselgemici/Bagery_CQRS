using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Handlers.BasketHandlers;
using MyAcademyCQRS.CQRSPattern.Queries.BasketQueries;
using MyAcademyCQRS.Entities; 
using System.Threading.Tasks;

namespace MyAcademyCQRS.ViewComponents.UILayout
{
    public class _DefaultHeaderComponentPartial : ViewComponent
    {
        private readonly GetBasketCountQueryHandler _getBasketCountQueryHandler;
        private readonly UserManager<AppUser> _userManager; 

        public _DefaultHeaderComponentPartial(GetBasketCountQueryHandler getBasketCountQueryHandler, UserManager<AppUser> userManager)
        {
            _getBasketCountQueryHandler = getBasketCountQueryHandler;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                if (user != null)
                {
                    int count = _getBasketCountQueryHandler.Handle(new GetBasketCountQuery { UserId = user.Id });
                    return View(count);
                }
            }

            // Giriş yapmamışsa sepet 0 görünsün
            return View(0);
        }
    }
}
