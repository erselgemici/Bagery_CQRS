using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Results.FeatureResults;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAcademyCQRS.CQRSPattern.Handlers.FeatureHandlers
{
    public class GetFeatureQueryHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetFeatureQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<GetFeatureQueryResult>> Handle()
        {
            var values = await _uow.GetRepository<Feature>().GetAllAsync();
            return _mapper.Map<List<GetFeatureQueryResult>>(values);
        }
    }
}
