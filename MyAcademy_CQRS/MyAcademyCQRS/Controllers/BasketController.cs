using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.BasketCommands;
using MyAcademyCQRS.CQRSPattern.Commands.OrderCommands;
using MyAcademyCQRS.CQRSPattern.Handlers.BasketHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.OrderHandlers;
using MyAcademyCQRS.CQRSPattern.Queries.BasketQueries;
using MyAcademyCQRS.Entities;
using MyAcademyCQRS.DesignPatterns.ChainOfResponsibility;
using System;
using System.Linq; 
using System.Threading.Tasks;

namespace MyAcademyCQRS.Controllers
{
    public class BasketController : Controller
    {
        private readonly CreateBasketItemCommandHandler _createBasketItemCommandHandler;
        private readonly UserManager<AppUser> _userManager;
        private readonly GetBasketByUserIdQueryHandler _getBasketByUserIdQueryHandler;
        private readonly RemoveBasketItemCommandHandler _removeBasketItemCommandHandler;
        private readonly IncreaseBasketItemCommandHandler _increaseBasketItemCommandHandler;
        private readonly DecreaseBasketItemCommandHandler _decreaseBasketItemCommandHandler;

        private readonly CreateOrderCommandHandler _createOrderCommandHandler;

        private readonly AppDbContext _context;

        public BasketController(
            CreateBasketItemCommandHandler createBasketItemCommandHandler,
            UserManager<AppUser> userManager,
            GetBasketByUserIdQueryHandler getBasketByUserIdQueryHandler,
            RemoveBasketItemCommandHandler removeBasketItemCommandHandler,
            IncreaseBasketItemCommandHandler increaseBasketItemCommandHandler,
            DecreaseBasketItemCommandHandler decreaseBasketItemCommandHandler,
            CreateOrderCommandHandler createOrderCommandHandler,
            AppDbContext context)
        {
            _createBasketItemCommandHandler = createBasketItemCommandHandler;
            _userManager = userManager;
            _getBasketByUserIdQueryHandler = getBasketByUserIdQueryHandler;
            _removeBasketItemCommandHandler = removeBasketItemCommandHandler;
            _increaseBasketItemCommandHandler = increaseBasketItemCommandHandler;
            _decreaseBasketItemCommandHandler = decreaseBasketItemCommandHandler;
            _createOrderCommandHandler = createOrderCommandHandler;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> AddBasket(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null) return RedirectToAction("Index", "Login");

            var command = new CreateBasketItemCommand
            {
                ProductId = id,
                Quantity = 1,
                UserId = user.Id
            };

            _createBasketItemCommandHandler.Handle(command);
            return RedirectToAction("Index", "Shop");
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null) return RedirectToAction("Index", "Login");

            var values = _getBasketByUserIdQueryHandler.Handle(new GetBasketByUserIdQuery { UserId = user.Id });
            return View(values);
        }

        public IActionResult DeleteBasketItem(int id)
        {
            _removeBasketItemCommandHandler.Handle(new RemoveBasketItemCommand(id));
            return RedirectToAction("Index");
        }

        public IActionResult IncreaseBasketItem(int id)
        {
            _increaseBasketItemCommandHandler.Handle(new IncreaseBasketItemCommand(id));
            return RedirectToAction("Index");
        }

        public IActionResult DecreaseBasketItem(int id)
        {
            _decreaseBasketItemCommandHandler.Handle(new DecreaseBasketItemCommand(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> CompleteOrder()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null) return RedirectToAction("Index", "Login");

            var command = new CreateOrderCommand { UserId = user.Id };


            // Zincirin Halkalarını Oluştur 
            var stockHandler = new MyAcademyCQRS.DesignPatterns.ChainOfResponsibility.CheckStockHandler(_context);
            var paymentHandler = new MyAcademyCQRS.DesignPatterns.ChainOfResponsibility.PaymentHandler();
            var createOrderChainHandler = new MyAcademyCQRS.DesignPatterns.ChainOfResponsibility.CreateOrderHandler(_context);

            // Sıralamayı Belirle: Stok -> Ödeme -> Sipariş Kaydı
            stockHandler.SetNext(paymentHandler);
            paymentHandler.SetNext(createOrderChainHandler);

            try
            {
                // Zinciri Tetikle
                stockHandler.Handle(command);

                var lastOrder = _context.Orders
                                        .Where(x => x.UserId == user.Id)
                                        .OrderByDescending(x => x.OrderId)
                                        .FirstOrDefault();

                if (lastOrder != null)
                {
                    TempData["icon"] = "success";
                    TempData["title"] = "Siparişiniz Başarıyla Alındı!";
                    TempData["OrderId"] = lastOrder.OrderId;
                    TempData["Date"] = lastOrder.OrderDate.ToString("dd.MM.yyyy HH:mm");
                    TempData["TotalPrice"] = lastOrder.TotalPrice.ToString("N2");
                }
            }
            catch (Exception ex)
            {
                TempData["icon"] = "error";
                TempData["title"] = "Hata: " + ex.Message;
                TempData["TotalPrice"] = "0";
            }

            return RedirectToAction("Index");
        }
    }
}
