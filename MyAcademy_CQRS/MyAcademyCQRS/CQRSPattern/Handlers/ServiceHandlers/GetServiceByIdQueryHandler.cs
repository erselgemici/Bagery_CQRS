using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Queries.ServiceQueries;
using MyAcademyCQRS.CQRSPattern.Results.ServiceResults;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;
using System.Threading.Tasks;

namespace MyAcademyCQRS.CQRSPattern.Handlers.ServiceHandlers
{
    public class GetServiceByIdQueryHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetServiceByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery query)
        {
            var value = await _uow.GetRepository<Service>().GetByIdAsync(query.Id);
            return _mapper.Map<GetServiceByIdQueryResult>(value);
        }
    }
}
