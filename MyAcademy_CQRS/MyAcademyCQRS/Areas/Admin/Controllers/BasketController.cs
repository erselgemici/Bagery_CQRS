using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAcademyCQRS.CQRSPattern.Commands.BasketCommands;
using MyAcademyCQRS.CQRSPattern.Handlers.BasketHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.ProductHandlers;
using MyAcademyCQRS.CQRSPattern.Queries.BasketQueries;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAcademyCQRS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BasketController : Controller
    {
        private readonly GetBasketQueryHandler _getBasketQueryHandler;
        private readonly CreateBasketCommandHandler _createBasketCommandHandler;
        private readonly RemoveBasketCommandHandler _removeBasketCommandHandler;
        private readonly GetBasketByIdQueryHandler _getBasketByIdQueryHandler;
        private readonly UpdateBasketCommandHandler _updateBasketCommandHandler;

        // Ürün listesi için (Dropdown)
        private readonly GetProductQueryHandler _getProductQueryHandler;

        public BasketController(
            GetBasketQueryHandler getBasketQueryHandler,
            CreateBasketCommandHandler createBasketCommandHandler,
            RemoveBasketCommandHandler removeBasketCommandHandler,
            GetBasketByIdQueryHandler getBasketByIdQueryHandler,
            UpdateBasketCommandHandler updateBasketCommandHandler,
            GetProductQueryHandler getProductQueryHandler)
        {
            _getBasketQueryHandler = getBasketQueryHandler;
            _createBasketCommandHandler = createBasketCommandHandler;
            _removeBasketCommandHandler = removeBasketCommandHandler;
            _getBasketByIdQueryHandler = getBasketByIdQueryHandler;
            _updateBasketCommandHandler = updateBasketCommandHandler;
            _getProductQueryHandler = getProductQueryHandler;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _getBasketQueryHandler.Handle();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateBasket()
        {
            var products = await _getProductQueryHandler.Handle();
            List<SelectListItem> productList = (from x in products
                                                select new SelectListItem
                                                {
                                                    Text = x.ProductName,
                                                    Value = x.ProductId.ToString()
                                                }).ToList();
            ViewBag.ProductList = productList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBasket(CreateBasketCommand command)
        {
            await _createBasketCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteBasket(int id)
        {
            await _removeBasketCommandHandler.Handle(new RemoveBasketCommand(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBasket(int id)
        {
            var products = await _getProductQueryHandler.Handle();
            List<SelectListItem> productList = (from x in products
                                                select new SelectListItem
                                                {
                                                    Text = x.ProductName,
                                                    Value = x.ProductId.ToString()
                                                }).ToList();
            ViewBag.ProductList = productList;

            var value = await _getBasketByIdQueryHandler.Handle(new GetBasketByIdQuery(id));
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBasket(UpdateBasketCommand command)
        {
            await _updateBasketCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
    }
}
