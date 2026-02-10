using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.OrderCommands;
using MyAcademyCQRS.Entities;
// 👇 Observer Namespace'ini ekle
using MyAcademyCQRS.DesignPatterns.Observer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyAcademyCQRS.DesignPatterns.ChainOfResponsibility
{
    public class CreateOrderHandler : OrderHandlerBase
    {
        private readonly AppDbContext _context;

        public CreateOrderHandler(AppDbContext context)
        {
            _context = context;
        }

        public override void Handle(CreateOrderCommand command)
        {
            // 1. Sepeti Getir
            var basket = _context.Baskets.Include(x => x.BasketItems).FirstOrDefault(x => x.UserId == command.UserId);

            // 2. Siparişi Oluştur
            var order = new Order
            {
                UserId = command.UserId,
                OrderDate = DateTime.Now,
                TotalPrice = basket.BasketItems.Sum(x => x.Price * x.Quantity),
                OrderDetails = new List<OrderDetail>()
            };

            foreach (var item in basket.BasketItems)
            {
                order.OrderDetails.Add(new OrderDetail
                {
                    ProductId = item.ProductId,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    OrderId = order.OrderId
                });
            }

            _context.Orders.Add(order);
            _context.BasketItems.RemoveRange(basket.BasketItems);

            _context.SaveChanges(); // Sipariş ID oluştu


            ObserverObject observerObject = new ObserverObject();

            observerObject.RegisterObserver(new DbLoggerObserver(_context));

            observerObject.NotifyObservers(
                $"Yeni Sipariş Oluşturuldu - Sipariş No: {order.OrderId}", 
                "Sipariş (Chain)",                                         
                $"Tutar: {order.TotalPrice}₺"                              
            );

        }
    }
}
