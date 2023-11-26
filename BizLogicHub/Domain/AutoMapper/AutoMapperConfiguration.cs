using AutoMapper;
using Domain.Command;
using Domain.Query;
using Model.Dto;
using Model.Dto.Commands;
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

            CreateMap<Mentor, MentorDto>().ReverseMap();
            CreateMap<MentorDto, Mentor>().ReverseMap();

            CreateMap<Review, ReviewDto>().ReverseMap();
            CreateMap<ReviewDto, Review>().ReverseMap();

            CreateMap<GetUniversityQuery, GetUniversityQueryDto>().ReverseMap();

            CreateMap<GetMentorListQuery, GetMentorListQueryDto>().ReverseMap();

            
            CreateMap<ReviewCommandDto, Review>().ReverseMap();
            CreateMap<AddReviewCommand, ReviewCommandDto>().ReverseMap();
            CreateMap<AddMentorCommand, MentorCommandDto>().ReverseMap();
            CreateMap<MentorCommandDto, Mentor>().ReverseMap();
            CreateMap<AddUniversityCommand, UniversityCommandDto>().ReverseMap();
            CreateMap<UniversityCommandDto, University>().ReverseMap();

        }
    }
}
