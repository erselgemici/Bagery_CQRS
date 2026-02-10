using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Results.BasketResults;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAcademyCQRS.CQRSPattern.Handlers.BasketHandlers
{
    public class GetBasketQueryHandler
    {
        private readonly IUnitOfWork _uow; 
        private readonly IMapper _mapper;

        public GetBasketQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<GetBasketQueryResult>> Handle()
        {
            var values = await _uow.GetRepository<BasketItem>().GetAllAsync(x => x.Product);
            return _mapper.Map<List<GetBasketQueryResult>>(values);
        }
    }
}
