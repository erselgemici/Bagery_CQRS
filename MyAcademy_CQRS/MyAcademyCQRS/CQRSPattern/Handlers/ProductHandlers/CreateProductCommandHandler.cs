using AutoMapper;
using Microsoft.CodeAnalysis;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.ProductCommands;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.Handlers.ProductHandlers
{
    public class CreateProductCommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task Handle(CreateProductCommand command)
        {
            var product = _mapper.Map<Product>(command);
            await _uow.GetRepository<Product>().CreateAsync(product);
            await _uow.SaveChangesAsync();
        }
    }
}
