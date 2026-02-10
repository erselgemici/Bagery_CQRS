using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Commands.ContactInfoCommands;
using MyAcademyCQRS.CQRSPattern.Handlers.ContactInfoHandlers;
using MyAcademyCQRS.CQRSPattern.Queries.ContactInfoQueries;
using System.Threading.Tasks;

namespace MyAcademyCQRS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ContactInfoController : Controller
    {
        private readonly GetContactInfoQueryHandler _getContactInfoQueryHandler;
        private readonly CreateContactInfoCommandHandler _createContactInfoCommandHandler;
        private readonly RemoveContactInfoCommandHandler _removeContactInfoCommandHandler;
        private readonly GetContactInfoByIdQueryHandler _getContactInfoByIdQueryHandler;
        private readonly UpdateContactInfoCommandHandler _updateContactInfoCommandHandler;

        public ContactInfoController(
            GetContactInfoQueryHandler getContactInfoQueryHandler,
            CreateContactInfoCommandHandler createContactInfoCommandHandler,
            RemoveContactInfoCommandHandler removeContactInfoCommandHandler,
            GetContactInfoByIdQueryHandler getContactInfoByIdQueryHandler,
            UpdateContactInfoCommandHandler updateContactInfoCommandHandler)
        {
            _getContactInfoQueryHandler = getContactInfoQueryHandler;
            _createContactInfoCommandHandler = createContactInfoCommandHandler;
            _removeContactInfoCommandHandler = removeContactInfoCommandHandler;
            _getContactInfoByIdQueryHandler = getContactInfoByIdQueryHandler;
            _updateContactInfoCommandHandler = updateContactInfoCommandHandler;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _getContactInfoQueryHandler.Handle();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateContactInfo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContactInfo(CreateContactInfoCommand command)
        {
            await _createContactInfoCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteContactInfo(int id)
        {
            await _removeContactInfoCommandHandler.Handle(new RemoveContactInfoCommand(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateContactInfo(int id)
        {
            var value = await _getContactInfoByIdQueryHandler.Handle(new GetContactInfoByIdQuery(id));
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContactInfo(UpdateContactInfoCommand command)
        {
            await _updateContactInfoCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
    }
}
