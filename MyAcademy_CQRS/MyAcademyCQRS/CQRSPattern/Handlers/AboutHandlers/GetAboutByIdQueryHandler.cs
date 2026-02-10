using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Queries.AboutQueries;
using MyAcademyCQRS.CQRSPattern.Results.AboutResults;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;

public class GetAboutByIdQueryHandler
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetAboutByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery query)
    {
        var value = await _uow.GetRepository<About>().GetByIdAsync(query.Id);
        return _mapper.Map<GetAboutByIdQueryResult>(value);
    }
}
