using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Queries.FeatureQueries;
using MyAcademyCQRS.CQRSPattern.Results.FeatureResults;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;
using System.Threading.Tasks;

namespace MyAcademyCQRS.CQRSPattern.Handlers.FeatureHandlers
{
    public class GetFeatureByIdQueryHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetFeatureByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery query)
        {
            var value = await _uow.GetRepository<Feature>().GetByIdAsync(query.Id);
            return _mapper.Map<GetFeatureByIdQueryResult>(value);
        }
    }
}
