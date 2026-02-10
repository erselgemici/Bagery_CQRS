using MyAcademyCQRS.CQRSPattern.Handlers.AboutHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.BasketHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.CategoryHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.ContactHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.ContactInfoHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.FeatureHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.LogHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.NewsHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.OrderHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.PhotoGalleryHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.ProductHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.PromotionHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.ServiceHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.SliderHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.TestimonialHandlers;
using MyAcademyCQRS.Entities;
using System.Reflection;

namespace MyAcademyCQRS.Extensions
{
    public static class ServiceRegistrations
    {
        public static void AddCQRSHandlers(this IServiceCollection services)
        {
            services.AddScoped<GetCategoryQueryHandler>();
            services.AddScoped<GetCategoryByIdQueryHandler>();
            services.AddScoped<UpdateCategoryCommandHandler>();
            services.AddScoped<CreateCategoryCommandHandler>();
            services.AddScoped<RemoveCategoryCommandHandler>();


            services.AddScoped<GetProductQueryHandler>();
            services.AddScoped<CreateProductCommandHandler>();
            services.AddScoped<GetProductByIdQueryHandler>();
            services.AddScoped<UpdateProductCommandHandler>();
            services.AddScoped<RemoveProductCommandHandler>();

            services.AddScoped<GetSliderQueryHandler>();
            services.AddScoped<CreateSliderCommandHandler>();
            services.AddScoped<GetSliderByIdQueryHandler>();
            services.AddScoped<UpdateSliderCommandHandler>();
            services.AddScoped<RemoveSliderCommandHandler>();

            services.AddScoped<GetFeatureQueryHandler>();
            services.AddScoped<GetFeatureByIdQueryHandler>();
            services.AddScoped<UpdateFeatureCommandHandler>();
            services.AddScoped<CreateFeatureCommandHandler>();
            services.AddScoped<RemoveFeatureCommandHandler>();

            services.AddScoped<GetAboutQueryHandler>();
            services.AddScoped<GetAboutByIdQueryHandler>();
            services.AddScoped<UpdateAboutCommandHandler>();
            services.AddScoped<CreateAboutCommandHandler>();
            services.AddScoped<RemoveAboutCommandHandler>();

            services.AddScoped<GetServiceQueryHandler>();
            services.AddScoped<GetServiceByIdQueryHandler>();
            services.AddScoped<UpdateServiceCommandHandler>();
            services.AddScoped<CreateServiceCommandHandler>();
            services.AddScoped<RemoveServiceCommandHandler>();

            services.AddScoped<GetPhotoGalleryQueryHandler>();
            services.AddScoped<GetPhotoGalleryByIdQueryHandler>();
            services.AddScoped<UpdatePhotoGalleryCommandHandler>();
            services.AddScoped<CreatePhotoGalleryCommandHandler>();
            services.AddScoped<RemovePhotoGalleryCommandHandler>();

            services.AddScoped<GetPromotionQueryHandler>();
            services.AddScoped<CreatePromotionCommandHandler>();
            services.AddScoped<GetPromotionByIdQueryHandler>();
            services.AddScoped<UpdatePromotionCommandHandler>();
            services.AddScoped<RemovePromotionCommandHandler>();

            services.AddScoped<GetTestimonialQueryHandler>();
            services.AddScoped<CreateTestimonialCommandHandler>();
            services.AddScoped<GetTestimonialByIdQueryHandler>();
            services.AddScoped<UpdateTestimonialCommandHandler>();
            services.AddScoped<RemoveTestimonialCommandHandler>();

            services.AddScoped<GetNewsQueryHandler>();
            services.AddScoped<GetNewsByIdQueryHandler>();
            services.AddScoped<UpdateNewsCommandHandler>();
            services.AddScoped<CreateNewsCommandHandler>();
            services.AddScoped<RemoveNewsCommandHandler>();

            services.AddScoped<GetContactInfoQueryHandler>();
            services.AddScoped<GetContactInfoByIdQueryHandler>();
            services.AddScoped<UpdateContactInfoCommandHandler>();
            services.AddScoped<CreateContactInfoCommandHandler>();
            services.AddScoped<RemoveContactInfoCommandHandler>();

            services.AddScoped<CreateBasketItemCommandHandler>();
            services.AddScoped<RemoveBasketItemCommandHandler>();
            services.AddScoped<IncreaseBasketItemCommandHandler>();
            services.AddScoped<DecreaseBasketItemCommandHandler>();

            services.AddScoped<GetBasketCountQueryHandler>();
            services.AddScoped<GetBasketQueryHandler>();
            services.AddScoped<GetBasketByUserIdQueryHandler>();
            services.AddScoped<GetBasketQueryHandler>();
            services.AddScoped<CreateBasketCommandHandler>();
            services.AddScoped<UpdateBasketCommandHandler>();
            services.AddScoped<RemoveBasketCommandHandler>();
            services.AddScoped<GetBasketByIdQueryHandler>();

            services.AddScoped<CreateOrderCommandHandler>();

            services.AddScoped<GetLogQueryHandler>();

            services.AddScoped<CreateContactCommandHandler>();
        }

        public static void AddPackageExtensions(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
