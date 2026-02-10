using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Handlers.LogHandlers;
using MyAcademyCQRS.CQRSPattern.Queries.LogQueries;
using System.Threading.Tasks;

namespace MyAcademyCQRS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class LogController : Controller
    {
        private readonly GetLogQueryHandler _getLogQueryHandler;

        public LogController(GetLogQueryHandler getLogQueryHandler)
        {
            _getLogQueryHandler = getLogQueryHandler;
        }

        public async Task<IActionResult> Index(string searchKey)
        {
            ViewBag.SearchKey = searchKey;

            var values = await _getLogQueryHandler.Handle(new GetLogQuery(searchKey));
            return View(values);
        }
    }
}
