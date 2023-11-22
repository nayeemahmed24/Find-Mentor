using AutoMapper;
using Domain.Query;
using Model.Dto;
using Model.Dto.Qureies;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AutoMapper
{
    public class AutoMapperConfiguration: Profile
    {
        public AutoMapperConfiguration() 
        {
            CreateMap<University, UniversityDto>().ReverseMap();
            CreateMap<UniversityDto, University>().ReverseMap();
            CreateMap<GetUniversityQuery, GetUniversityQueryDto>().ReverseMap();

            CreateMap<Mentor, MentorDto>().ReverseMap();
            CreateMap<GetMentorListQuery, GetMentorListQueryDto>().ReverseMap();
        }
    }
}
