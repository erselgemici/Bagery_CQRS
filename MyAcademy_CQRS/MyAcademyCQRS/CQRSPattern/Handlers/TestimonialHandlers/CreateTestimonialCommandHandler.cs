using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Commands.TestimonialCommands;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;
using System.Threading.Tasks;

namespace MyAcademyCQRS.CQRSPattern.Handlers.TestimonialHandlers
{
    public class CreateTestimonialCommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CreateTestimonialCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task Handle(CreateTestimonialCommand command)
        {
            var testimonial = _mapper.Map<Testimonial>(command);
            await _uow.GetRepository<Testimonial>().CreateAsync(testimonial);
            await _uow.SaveChangesAsync();
        }
    }
}
