using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Commands.SliderCommands;
using MyAcademyCQRS.CQRSPattern.Handlers.SliderHandlers;
using MyAcademyCQRS.CQRSPattern.Queries.SliderQueries;
using System.Threading.Tasks;

namespace MyAcademyCQRS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SliderController : Controller
    {
        private readonly GetSliderQueryHandler _getSliderQueryHandler;
        private readonly CreateSliderCommandHandler _createSliderCommandHandler;
        private readonly RemoveSliderCommandHandler _removeSliderCommandHandler;
        private readonly GetSliderByIdQueryHandler _getSliderByIdQueryHandler;
        private readonly UpdateSliderCommandHandler _updateSliderCommandHandler;

        public SliderController(
            GetSliderQueryHandler getSliderQueryHandler,
            CreateSliderCommandHandler createSliderCommandHandler,
            RemoveSliderCommandHandler removeSliderCommandHandler,
            GetSliderByIdQueryHandler getSliderByIdQueryHandler,
            UpdateSliderCommandHandler updateSliderCommandHandler)
        {
            _getSliderQueryHandler = getSliderQueryHandler;
            _createSliderCommandHandler = createSliderCommandHandler;
            _removeSliderCommandHandler = removeSliderCommandHandler;
            _getSliderByIdQueryHandler = getSliderByIdQueryHandler;
            _updateSliderCommandHandler = updateSliderCommandHandler;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _getSliderQueryHandler.Handle();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateSlider()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSlider(CreateSliderCommand command)
        {
            await _createSliderCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteSlider(int id)
        {
            await _removeSliderCommandHandler.Handle(new RemoveSliderCommand(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSlider(int id)
        {
            var value = await _getSliderByIdQueryHandler.Handle(new GetSliderByIdQuery(id));
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSlider(UpdateSliderCommand command)
        {
            await _updateSliderCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
    }
}
