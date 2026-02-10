using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Queries.TestimonialQueries;
using MyAcademyCQRS.CQRSPattern.Results.TestimonialResults;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;
using System.Threading.Tasks;

namespace MyAcademyCQRS.CQRSPattern.Handlers.TestimonialHandlers
{
    public class GetTestimonialByIdQueryHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetTestimonialByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery query)
        {
            var value = await _uow.GetRepository<Testimonial>().GetByIdAsync(query.Id);
            return _mapper.Map<GetTestimonialByIdQueryResult>(value);
        }
    }
}
