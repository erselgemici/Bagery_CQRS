using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Commands.PromotionCommands;
using MyAcademyCQRS.CQRSPattern.Handlers.PromotionHandlers;
using MyAcademyCQRS.CQRSPattern.Queries.PromotionQueries;
using System.Threading.Tasks;

namespace MyAcademyCQRS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PromotionController : Controller
    {
        private readonly GetPromotionQueryHandler _getPromotionQueryHandler;
        private readonly CreatePromotionCommandHandler _createPromotionCommandHandler;
        private readonly RemovePromotionCommandHandler _removePromotionCommandHandler;
        private readonly GetPromotionByIdQueryHandler _getPromotionByIdQueryHandler;
        private readonly UpdatePromotionCommandHandler _updatePromotionCommandHandler;

        public PromotionController(
            GetPromotionQueryHandler getPromotionQueryHandler,
            CreatePromotionCommandHandler createPromotionCommandHandler,
            RemovePromotionCommandHandler removePromotionCommandHandler,
            GetPromotionByIdQueryHandler getPromotionByIdQueryHandler,
            UpdatePromotionCommandHandler updatePromotionCommandHandler)
        {
            _getPromotionQueryHandler = getPromotionQueryHandler;
            _createPromotionCommandHandler = createPromotionCommandHandler;
            _removePromotionCommandHandler = removePromotionCommandHandler;
            _getPromotionByIdQueryHandler = getPromotionByIdQueryHandler;
            _updatePromotionCommandHandler = updatePromotionCommandHandler;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _getPromotionQueryHandler.Handle();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreatePromotion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePromotion(CreatePromotionCommand command)
        {
            await _createPromotionCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeletePromotion(int id)
        {
            await _removePromotionCommandHandler.Handle(new RemovePromotionCommand(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdatePromotion(int id)
        {
            var value = await _getPromotionByIdQueryHandler.Handle(new GetPromotionByIdQuery(id));
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePromotion(UpdatePromotionCommand command)
        {
            await _updatePromotionCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
    }
}
