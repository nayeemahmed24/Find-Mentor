using Model.Dto;
using Model.Dto.Commands;
using Model.Dto.Qureies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstractions
{
    public interface IMentorService
    {
        public Task<List<MentorDto>> GetMentorDtos(string correlationId, GetMentorListQueryDto query);
        public Task<MentorDto> GetMentorDetails(string correlationId, string mentorId);
        public Task<MentorDto> AddMentor(string correlationId, MentorCommandDto commandDto);
    }
}
