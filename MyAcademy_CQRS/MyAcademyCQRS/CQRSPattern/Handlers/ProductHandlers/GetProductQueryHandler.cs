using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Results.ProductResults;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.Handlers.ProductHandlers
{
    public class GetProductQueryHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<GetProductQueryResult>> Handle()
        {
            var values = await _uow.GetRepository<Product>().GetAllAsync(x => x.Category);
            return _mapper.Map<List<GetProductQueryResult>>(values);
        }
    }
}
