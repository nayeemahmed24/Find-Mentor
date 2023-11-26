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
    public interface IUniversityService
    {
        Task<List<UniversityDto>> GetUniversityListAsync(string correlationId, GetUniversityQueryDto query);
        Task<UniversityDto> GetUniversityDetails(string correlationId, string universityId);
        Task<UniversityDto> AddUniversity(string correlationId, UniversityCommandDto commandDto);
    }
}
