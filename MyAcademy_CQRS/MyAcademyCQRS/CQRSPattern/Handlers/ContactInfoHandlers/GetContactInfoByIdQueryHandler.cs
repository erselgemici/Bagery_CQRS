using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Queries.ContactInfoQueries;
using MyAcademyCQRS.CQRSPattern.Results.ContactInfoResults;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;
using System.Threading.Tasks;

namespace MyAcademyCQRS.CQRSPattern.Handlers.ContactInfoHandlers
{
    public class GetContactInfoByIdQueryHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetContactInfoByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<GetContactInfoByIdQueryResult> Handle(GetContactInfoByIdQuery query)
        {
            var value = await _uow.GetRepository<ContactInfo>().GetByIdAsync(query.Id);
            return _mapper.Map<GetContactInfoByIdQueryResult>(value);
        }
    }
}
