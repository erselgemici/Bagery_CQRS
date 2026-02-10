using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Commands.PhotoGalleryCommands;
using MyAcademyCQRS.CQRSPattern.Handlers.PhotoGalleryHandlers;
using MyAcademyCQRS.CQRSPattern.Queries.PhotoGalleryQueries;
using System.Threading.Tasks;

namespace MyAcademyCQRS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PhotoGalleryController : Controller
    {
        private readonly GetPhotoGalleryQueryHandler _getPhotoGalleryQueryHandler;
        private readonly CreatePhotoGalleryCommandHandler _createPhotoGalleryCommandHandler;
        private readonly RemovePhotoGalleryCommandHandler _removePhotoGalleryCommandHandler;
        private readonly GetPhotoGalleryByIdQueryHandler _getPhotoGalleryByIdQueryHandler;
        private readonly UpdatePhotoGalleryCommandHandler _updatePhotoGalleryCommandHandler;

        public PhotoGalleryController(
            GetPhotoGalleryQueryHandler getPhotoGalleryQueryHandler,
            CreatePhotoGalleryCommandHandler createPhotoGalleryCommandHandler,
            RemovePhotoGalleryCommandHandler removePhotoGalleryCommandHandler,
            GetPhotoGalleryByIdQueryHandler getPhotoGalleryByIdQueryHandler,
            UpdatePhotoGalleryCommandHandler updatePhotoGalleryCommandHandler)
        {
            _getPhotoGalleryQueryHandler = getPhotoGalleryQueryHandler;
            _createPhotoGalleryCommandHandler = createPhotoGalleryCommandHandler;
            _removePhotoGalleryCommandHandler = removePhotoGalleryCommandHandler;
            _getPhotoGalleryByIdQueryHandler = getPhotoGalleryByIdQueryHandler;
            _updatePhotoGalleryCommandHandler = updatePhotoGalleryCommandHandler;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _getPhotoGalleryQueryHandler.Handle();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreatePhotoGallery()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePhotoGallery(CreatePhotoGalleryCommand command)
        {
            await _createPhotoGalleryCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeletePhotoGallery(int id)
        {
            await _removePhotoGalleryCommandHandler.Handle(new RemovePhotoGalleryCommand(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdatePhotoGallery(int id)
        {
            var value = await _getPhotoGalleryByIdQueryHandler.Handle(new GetPhotoGalleryByIdQuery(id));
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePhotoGallery(UpdatePhotoGalleryCommand command)
        {
            await _updatePhotoGalleryCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
    }
}
