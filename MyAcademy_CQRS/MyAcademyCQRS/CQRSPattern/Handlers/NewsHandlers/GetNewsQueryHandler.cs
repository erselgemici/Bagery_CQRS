using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Results.NewsResults;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;

public class GetNewsQueryHandler
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetNewsQueryHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<List<GetNewsQueryResult>> Handle()
    {
        // Include yok
        var values = await _uow.GetRepository<News>().GetAllAsync();
        return _mapper.Map<List<GetNewsQueryResult>>(values);
    }
}
