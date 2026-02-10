using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Results.ServiceResults;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAcademyCQRS.CQRSPattern.Handlers.ServiceHandlers
{
    public class GetServiceQueryHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetServiceQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<GetServiceQueryResult>> Handle()
        {
            var values = await _uow.GetRepository<Service>().GetAllAsync();
            return _mapper.Map<List<GetServiceQueryResult>>(values);
        }
    }
}
