using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Commands.TestimonialCommands;
using MyAcademyCQRS.CQRSPattern.Queries.TestimonialQueries;
using MyAcademyCQRS.CQRSPattern.Results.TestimonialResults;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.Mappings
{
    public class TestimonialMappings : Profile
    {
        public TestimonialMappings()
        {
            CreateMap<Testimonial, GetTestimonialQueryResult>().ReverseMap();
            CreateMap<Testimonial, GetTestimonialByIdQueryResult>().ReverseMap();
            CreateMap<Testimonial, CreateTestimonialCommand>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialCommand>().ReverseMap();
            CreateMap<Testimonial, GetTestimonialByIdQuery>().ReverseMap();
        }
    }
}
