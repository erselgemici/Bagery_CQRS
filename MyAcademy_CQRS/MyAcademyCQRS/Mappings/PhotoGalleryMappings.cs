using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Commands.PhotoGalleryCommands;
using MyAcademyCQRS.CQRSPattern.Queries.PhotoGalleryQueries;
using MyAcademyCQRS.CQRSPattern.Results.PhotoGalleryResults;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.Mappings
{
    public class PhotoGalleryMappings : Profile
    {
        public PhotoGalleryMappings()
        {
            CreateMap<PhotoGallery, GetPhotoGalleryQueryResult>().ReverseMap();
            CreateMap<PhotoGallery, GetPhotoGalleryByIdQueryResult>().ReverseMap();
            CreateMap<PhotoGallery, CreatePhotoGalleryCommand>().ReverseMap();
            CreateMap<PhotoGallery, UpdatePhotoGalleryCommand>().ReverseMap();
            CreateMap<PhotoGallery, GetPhotoGalleryByIdQuery>().ReverseMap();
        }
    }
}
