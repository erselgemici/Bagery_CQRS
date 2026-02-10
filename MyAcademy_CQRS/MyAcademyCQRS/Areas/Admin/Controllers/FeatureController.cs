using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Commands.FeatureCommands;
using MyAcademyCQRS.CQRSPattern.Handlers.FeatureHandlers;
using MyAcademyCQRS.CQRSPattern.Queries.FeatureQueries;
using System.Threading.Tasks;

namespace MyAcademyCQRS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class FeatureController : Controller
    {
        private readonly GetFeatureQueryHandler _getFeatureQueryHandler;
        private readonly CreateFeatureCommandHandler _createFeatureCommandHandler;
        private readonly RemoveFeatureCommandHandler _removeFeatureCommandHandler;
        private readonly GetFeatureByIdQueryHandler _getFeatureByIdQueryHandler;
        private readonly UpdateFeatureCommandHandler _updateFeatureCommandHandler;

        public FeatureController(
            GetFeatureQueryHandler getFeatureQueryHandler,
            CreateFeatureCommandHandler createFeatureCommandHandler,
            RemoveFeatureCommandHandler removeFeatureCommandHandler,
            GetFeatureByIdQueryHandler getFeatureByIdQueryHandler,
            UpdateFeatureCommandHandler updateFeatureCommandHandler)
        {
            _getFeatureQueryHandler = getFeatureQueryHandler;
            _createFeatureCommandHandler = createFeatureCommandHandler;
            _removeFeatureCommandHandler = removeFeatureCommandHandler;
            _getFeatureByIdQueryHandler = getFeatureByIdQueryHandler;
            _updateFeatureCommandHandler = updateFeatureCommandHandler;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _getFeatureQueryHandler.Handle();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateFeature()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureCommand command)
        {
            await _createFeatureCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteFeature(int id)
        {
            await _removeFeatureCommandHandler.Handle(new RemoveFeatureCommand(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFeature(int id)
        {
            var value = await _getFeatureByIdQueryHandler.Handle(new GetFeatureByIdQuery(id));
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureCommand command)
        {
            await _updateFeatureCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
    }
}
