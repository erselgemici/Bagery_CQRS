using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.ProductCommands;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.Handlers.ProductHandlers
{
    public class UpdateProductCommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task Handle(UpdateProductCommand command)
        {
            var repository = _uow.GetRepository<Product>();
            var value = await repository.GetByIdAsync(command.ProductId);

            if (value != null)
            {
                _mapper.Map(command, value);
                repository.Update(value);
                await _uow.SaveChangesAsync();
            }
        }
    }
}
