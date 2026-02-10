using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Queries.NewsQueries;
using MyAcademyCQRS.CQRSPattern.Results.NewsResults;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;
using System.Threading.Tasks;

namespace MyAcademyCQRS.CQRSPattern.Handlers.NewsHandlers
{
    public class GetNewsByIdQueryHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetNewsByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<GetNewsByIdQueryResult> Handle(GetNewsByIdQuery query)
        {
            var value = await _uow.GetRepository<News>().GetByIdAsync(query.Id);
            return _mapper.Map<GetNewsByIdQueryResult>(value);
        }
    }
}
