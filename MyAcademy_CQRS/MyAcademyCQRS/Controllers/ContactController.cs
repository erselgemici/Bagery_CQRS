using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Commands.ContactCommands;
using MyAcademyCQRS.CQRSPattern.Handlers.ContactHandlers;
using System;
using System.Threading.Tasks;

namespace MyAcademyCQRS.Controllers
{
    public class ContactController : Controller
    {
        private readonly CreateContactCommandHandler _createContactCommandHandler;

        public ContactController(CreateContactCommandHandler createContactCommandHandler)
        {
            _createContactCommandHandler = createContactCommandHandler;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateContactCommand command)
        {
            command.SentDate = DateTime.Now;
            command.IsRead = false;

            await _createContactCommandHandler.Handle(command);

            TempData["MessageResult"] = "Mesajınız başarıyla iletildi. En kısa sürede dönüş yapacağız!";

            return RedirectToAction("Index");
        }
    }
}
