using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Results.TestimonialResults;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAcademyCQRS.CQRSPattern.Handlers.TestimonialHandlers
{
    public class GetTestimonialQueryHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetTestimonialQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<GetTestimonialQueryResult>> Handle()
        {
            var values = await _uow.GetRepository<Testimonial>().GetAllAsync();
            return _mapper.Map<List<GetTestimonialQueryResult>>(values);
        }
    }
}
