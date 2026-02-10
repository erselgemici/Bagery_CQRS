using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Commands.NewsCommands;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;

public class UpdateNewsCommandHandler
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public UpdateNewsCommandHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task Handle(UpdateNewsCommand command)
    {
        var repo = _uow.GetRepository<News>();
        var value = await repo.GetByIdAsync(command.NewsId);

        if (value != null)
        {
            _mapper.Map(command, value);
            repo.Update(value);
            await _uow.SaveChangesAsync();
        }
    }
}
