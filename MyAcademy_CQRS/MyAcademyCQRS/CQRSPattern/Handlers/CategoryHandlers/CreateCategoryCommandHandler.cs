using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Commands.CategoryCommands;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;
using System.Threading.Tasks;

namespace MyAcademyCQRS.CQRSPattern.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task Handle(CreateCategoryCommand command)
        {
            var category = _mapper.Map<Category>(command);

            await _uow.GetRepository<Category>().CreateAsync(category);

            await _uow.SaveChangesAsync();
        }
    }
}
