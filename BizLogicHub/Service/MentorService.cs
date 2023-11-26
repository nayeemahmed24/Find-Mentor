using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Model.Dto;
using Model.Dto.Commands;
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
    public class MentorService : IMentorService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public MentorService(IMapper mapper, ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
            _mapper = mapper;
            
        }

        public async Task<MentorDto> AddMentor(string correlationId, MentorCommandDto commandDto)
        {
            Mentor mentor = _mapper.Map<MentorCommandDto, Mentor>(commandDto);
            var res = await _context.Mentors.AddAsync(mentor);
            await _context.SaveChangesAsync();
            MentorDto mentorDto = _mapper.Map<Mentor, MentorDto>(res.Entity);
            return mentorDto;
        }

        public async Task<List<MentorDto>> GetMentorDtos(string correlationId, GetMentorListQueryDto query)
        {
            var resQuery = _context.Mentors.AsQueryable();
            if (query.Name != null)
            {
                resQuery = resQuery.Where(a => a.Name == query.Name);
            }

            if (query.UniversityName != null)
            {
                resQuery = resQuery.Where(a => a.University.Name == query.UniversityName);
            }

            if (query.SearchKey != null)
            {
                resQuery = resQuery.Where(a => a.Name.Contains(query.SearchKey) || a.ProfileDescription.Contains(query.SearchKey));
            }

            resQuery = resQuery.Skip((query.PageNumber - 1) * query.PageSize);
            resQuery = resQuery.Take(query.PageSize);
            resQuery = resQuery.Include(a => a.University);

            List<Mentor> mentors = await resQuery?.ToListAsync();
            List<MentorDto> result = _mapper.Map<List<Mentor>, List<MentorDto>>(mentors);
            return result;
        }

        public async Task<MentorDto> GetMentorDetails(string correlationId, string mentorId)
        {
            Mentor mentor = await _context.Mentors.Where(p => p.Id == mentorId)
                .Include(p => p.University)
                .Include(p => p.Reviews)
                .FirstOrDefaultAsync();

            MentorDto mentorDto = _mapper.Map<Mentor, MentorDto>(mentor);
            return mentorDto;
        }
    }
}
