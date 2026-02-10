using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Commands.NewsCommands;
using MyAcademyCQRS.CQRSPattern.Handlers.NewsHandlers;
using MyAcademyCQRS.CQRSPattern.Queries.NewsQueries;
using System.Threading.Tasks;

namespace MyAcademyCQRS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class NewsController : Controller
    {
        private readonly GetNewsQueryHandler _getNewsQueryHandler;
        private readonly CreateNewsCommandHandler _createNewsCommandHandler;
        private readonly RemoveNewsCommandHandler _removeNewsCommandHandler;
        private readonly GetNewsByIdQueryHandler _getNewsByIdQueryHandler;
        private readonly UpdateNewsCommandHandler _updateNewsCommandHandler;

        // CategoryHandler SİLİNDİ
        public NewsController(
            GetNewsQueryHandler getNewsQueryHandler,
            CreateNewsCommandHandler createNewsCommandHandler,
            RemoveNewsCommandHandler removeNewsCommandHandler,
            GetNewsByIdQueryHandler getNewsByIdQueryHandler,
            UpdateNewsCommandHandler updateNewsCommandHandler)
        {
            _getNewsQueryHandler = getNewsQueryHandler;
            _createNewsCommandHandler = createNewsCommandHandler;
            _removeNewsCommandHandler = removeNewsCommandHandler;
            _getNewsByIdQueryHandler = getNewsByIdQueryHandler;
            _updateNewsCommandHandler = updateNewsCommandHandler;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _getNewsQueryHandler.Handle();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateNews()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNews(CreateNewsCommand command)
        {
            await _createNewsCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteNews(int id)
        {
            await _removeNewsCommandHandler.Handle(new RemoveNewsCommand(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateNews(int id)
        {
            var value = await _getNewsByIdQueryHandler.Handle(new GetNewsByIdQuery(id));
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateNews(UpdateNewsCommand command)
        {
            await _updateNewsCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
    }
}
