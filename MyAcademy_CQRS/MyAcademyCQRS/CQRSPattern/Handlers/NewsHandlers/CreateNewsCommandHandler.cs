using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Commands.NewsCommands;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;

public class CreateNewsCommandHandler
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public CreateNewsCommandHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task Handle(CreateNewsCommand command)
    {
        var news = _mapper.Map<News>(command);
        await _uow.GetRepository<News>().CreateAsync(news);
        await _uow.SaveChangesAsync();
    }
}
