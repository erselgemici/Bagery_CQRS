using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.BasketCommands;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyAcademyCQRS.CQRSPattern.Handlers.BasketHandlers
{
    public class CreateBasketCommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateBasketCommandHandler(IUnitOfWork uow, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _uow = uow;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task Handle(CreateBasketCommand command)
        {
            var userIdString = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdString)) return;
            int.TryParse(userIdString, out int userId);

            var basketRepo = _uow.GetRepository<Basket>();

            var basket = await basketRepo.GetByFilterAsync(x => x.UserId == userId);

            if (basket == null)
            {
                basket = new Basket { UserId = userId };
                await basketRepo.CreateAsync(basket);
                await _uow.SaveChangesAsync();
            }

            var basketItem = _mapper.Map<BasketItem>(command);
            basketItem.BasketId = basket.BasketId;

            await _uow.GetRepository<BasketItem>().CreateAsync(basketItem);
            await _uow.SaveChangesAsync();
        }
    }
}
