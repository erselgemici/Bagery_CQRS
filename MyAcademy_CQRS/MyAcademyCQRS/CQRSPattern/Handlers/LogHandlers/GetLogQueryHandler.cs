using AutoMapper;
using Microsoft.EntityFrameworkCore; 
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Queries.LogQueries;
using MyAcademyCQRS.CQRSPattern.Results.LogResults;
using MyAcademyCQRS.DataAccess.Abstract; 
using MyAcademyCQRS.DataAccess.Concrete;
using MyAcademyCQRS.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAcademyCQRS.CQRSPattern.Handlers.LogHandlers
{
    public class GetLogQueryHandler
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetLogQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetLogQueryResult>> Handle(GetLogQuery query)
        {
            var logs = _context.Logs.AsQueryable();

            if (!string.IsNullOrEmpty(query.SearchKey))
            {
                logs = logs.Where(x => x.Message.Contains(query.SearchKey) || x.Section.Contains(query.SearchKey));
            }

            var values = await logs.OrderByDescending(x => x.LogId).ToListAsync();

            return _mapper.Map<List<GetLogQueryResult>>(values);
        }
    }
}
