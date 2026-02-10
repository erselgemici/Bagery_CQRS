using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Commands.ServiceCommands;
using MyAcademyCQRS.CQRSPattern.Handlers.ServiceHandlers;
using MyAcademyCQRS.CQRSPattern.Queries.ServiceQueries;
using System.Threading.Tasks;

namespace MyAcademyCQRS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ServiceController : Controller
    {
        private readonly GetServiceQueryHandler _getServiceQueryHandler;
        private readonly CreateServiceCommandHandler _createServiceCommandHandler;
        private readonly RemoveServiceCommandHandler _removeServiceCommandHandler;
        private readonly GetServiceByIdQueryHandler _getServiceByIdQueryHandler;
        private readonly UpdateServiceCommandHandler _updateServiceCommandHandler;

        public ServiceController(
            GetServiceQueryHandler getServiceQueryHandler,
            CreateServiceCommandHandler createServiceCommandHandler,
            RemoveServiceCommandHandler removeServiceCommandHandler,
            GetServiceByIdQueryHandler getServiceByIdQueryHandler,
            UpdateServiceCommandHandler updateServiceCommandHandler)
        {
            _getServiceQueryHandler = getServiceQueryHandler;
            _createServiceCommandHandler = createServiceCommandHandler;
            _removeServiceCommandHandler = removeServiceCommandHandler;
            _getServiceByIdQueryHandler = getServiceByIdQueryHandler;
            _updateServiceCommandHandler = updateServiceCommandHandler;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _getServiceQueryHandler.Handle();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceCommand command)
        {
            await _createServiceCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteService(int id)
        {
            await _removeServiceCommandHandler.Handle(new RemoveServiceCommand(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateService(int id)
        {
            var value = await _getServiceByIdQueryHandler.Handle(new GetServiceByIdQuery(id));
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateService(UpdateServiceCommand command)
        {
            await _updateServiceCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
    }
}
