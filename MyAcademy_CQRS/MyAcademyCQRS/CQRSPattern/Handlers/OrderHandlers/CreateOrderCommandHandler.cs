using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.OrderCommands;
using MyAcademyCQRS.DesignPatterns.Observer;
using MyAcademyCQRS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyAcademyCQRS.CQRSPattern.Handlers.OrderHandlers
{
    public class CreateOrderCommandHandler
    {
        private readonly AppDbContext _context;

        public CreateOrderCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public Order Handle(CreateOrderCommand command)
        {
            var basket = _context.Baskets.Include(x => x.BasketItems)
                                         .FirstOrDefault(x => x.UserId == command.UserId);

            if (basket == null || !basket.BasketItems.Any()) return null;

            var order = new Order
            {
                UserId = command.UserId,
                OrderDate = DateTime.Now,
                TotalPrice = basket.BasketItems.Sum(x => x.Price * x.Quantity),
                OrderDetails = new List<OrderDetail>()
            };

            foreach (var item in basket.BasketItems)
            {
                var orderDetail = new OrderDetail
                {
                    ProductId = item.ProductId,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    OrderId = order.OrderId
                };
                order.OrderDetails.Add(orderDetail);
            }

            _context.Orders.Add(order);



            _context.BasketItems.RemoveRange(basket.BasketItems);
            _context.SaveChanges();

            ObserverObject observerObject = new ObserverObject();

            observerObject.RegisterObserver(new DbLoggerObserver(_context));

            observerObject.NotifyObservers(
                $"Yeni Sipariş Alındı - Sipariş No: {order.OrderId}", // Mesaj
                "Order", // Kategori / Yer
                $"Toplam Tutar: {order.TotalPrice}₺ | Tarih: {order.OrderDate}" // Detay
            );

            return order;
        }
    }
}
