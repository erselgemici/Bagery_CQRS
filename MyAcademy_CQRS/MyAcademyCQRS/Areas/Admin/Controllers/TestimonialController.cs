using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Commands.TestimonialCommands;
using MyAcademyCQRS.CQRSPattern.Handlers.TestimonialHandlers;
using MyAcademyCQRS.CQRSPattern.Queries.TestimonialQueries;
using System.Threading.Tasks;

namespace MyAcademyCQRS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TestimonialController : Controller
    {
        private readonly GetTestimonialQueryHandler _getTestimonialQueryHandler;
        private readonly CreateTestimonialCommandHandler _createTestimonialCommandHandler;
        private readonly RemoveTestimonialCommandHandler _removeTestimonialCommandHandler;
        private readonly GetTestimonialByIdQueryHandler _getTestimonialByIdQueryHandler;
        private readonly UpdateTestimonialCommandHandler _updateTestimonialCommandHandler;

        public TestimonialController(
            GetTestimonialQueryHandler getTestimonialQueryHandler,
            CreateTestimonialCommandHandler createTestimonialCommandHandler,
            RemoveTestimonialCommandHandler removeTestimonialCommandHandler,
            GetTestimonialByIdQueryHandler getTestimonialByIdQueryHandler,
            UpdateTestimonialCommandHandler updateTestimonialCommandHandler)
        {
            _getTestimonialQueryHandler = getTestimonialQueryHandler;
            _createTestimonialCommandHandler = createTestimonialCommandHandler;
            _removeTestimonialCommandHandler = removeTestimonialCommandHandler;
            _getTestimonialByIdQueryHandler = getTestimonialByIdQueryHandler;
            _updateTestimonialCommandHandler = updateTestimonialCommandHandler;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _getTestimonialQueryHandler.Handle();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialCommand command)
        {
            await _createTestimonialCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            await _removeTestimonialCommandHandler.Handle(new RemoveTestimonialCommand(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var value = await _getTestimonialByIdQueryHandler.Handle(new GetTestimonialByIdQuery(id));
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialCommand command)
        {
            await _updateTestimonialCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
    }
}
