using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Results.ContactInfoResults;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAcademyCQRS.CQRSPattern.Handlers.ContactInfoHandlers
{
    public class GetContactInfoQueryHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetContactInfoQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<GetContactInfoQueryResult>> Handle()
        {
            var values = await _uow.GetRepository<ContactInfo>().GetAllAsync();
            return _mapper.Map<List<GetContactInfoQueryResult>>(values);
        }
    }
}
