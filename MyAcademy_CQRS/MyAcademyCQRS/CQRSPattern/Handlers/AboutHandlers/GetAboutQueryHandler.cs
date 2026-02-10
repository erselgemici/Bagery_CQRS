using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Results.AboutResults;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;

public class GetAboutQueryHandler
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetAboutQueryHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<List<GetAboutQueryResult>> Handle()
    {
        var values = await _uow.GetRepository<About>().GetAllAsync();
        return _mapper.Map<List<GetAboutQueryResult>>(values);
    }
}
