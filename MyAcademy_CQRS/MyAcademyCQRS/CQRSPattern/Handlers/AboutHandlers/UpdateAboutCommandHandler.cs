using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Commands.AboutCommands;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;

public class UpdateAboutCommandHandler
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public UpdateAboutCommandHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task Handle(UpdateAboutCommand command)
    {
        var value = await _uow.GetRepository<About>().GetByIdAsync(command.AboutId);
        if (value != null)
        {
            _mapper.Map(command, value);
            _uow.GetRepository<About>().Update(value);
            await _uow.SaveChangesAsync();
        }
    }
}
