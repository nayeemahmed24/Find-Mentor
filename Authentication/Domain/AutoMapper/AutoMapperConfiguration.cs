using AutoMapper;
using Domain.Command;
using Model.Dto;
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
        public AutoMapperConfiguration() { 
            CreateMap<RegisterCommand, UserDto>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
