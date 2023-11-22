using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Model.Dto;
using Model.Dto.Qureies;
using Model.Entities;
using Repository;
using Service.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UniversityService : IUniversityService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public UniversityService(IMapper mapper, ApplicationDbContext context)
        {
            this._mapper = mapper;
            this._context = context;
        }
        public async Task<List<UniversityDto>> GetUniversityListAsync(string correlationId, GetUniversityQueryDto query)
        {
            var resQuery = _context.Universities.AsQueryable();
            if(query.City != null)
            {
                resQuery = resQuery.Where(a => a.City == query.City);
            }

            if (query.Name != null)
            {
                resQuery = resQuery.Where(a => a.Name == query.Name);
            }

            if (query.Country != null)
            {
                resQuery = resQuery.Where(a => a.Country == query.Country);
            }

            if (query.SearchKey != null)
            {
                resQuery = resQuery.Where(a => a.Country.Contains(query.SearchKey) || a.City.Contains(query.SearchKey) || a.Name.Contains(query.SearchKey));
            }

            resQuery = resQuery.Skip(query.PageNumber * query.PageSize);
            resQuery = resQuery.Take(query.PageSize);

            List<University> universities = await resQuery?.ToListAsync();
            List<UniversityDto> result = _mapper.Map<List<University>, List<UniversityDto>>(universities);
            return result;
        }
    }
}
