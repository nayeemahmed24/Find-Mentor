using AutoMapper;
using Domain.Query;
using MediatR;
using Model.Dto;
using Model.Dto.Qureies;
using Model.Response;
using Service.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.QueryHandler
{
    public class GetUniversityHandler : IRequestHandler<GetUniversityQuery, QueryResponse<List<UniversityDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IUniversityService universityService;
        public GetUniversityHandler(IMapper mapper, IUniversityService universityService) 
        {
            this._mapper = mapper;
            this.universityService = universityService;
        }

        public async Task<QueryResponse<List<UniversityDto>>> Handle(GetUniversityQuery request, CancellationToken cancellationToken)
        {
            try
            {
                GetUniversityQueryDto query = _mapper.Map<GetUniversityQuery, GetUniversityQueryDto>(request);
                List<UniversityDto> universityDtos = await this.universityService.GetUniversityListAsync(request.CorrelationId, query);
                return new QueryResponse<List<UniversityDto>>(universityDtos, HttpStatusCode.OK, null);
            }
            catch (Exception ex) 
            {
                return new QueryResponse<List<UniversityDto>>(null, HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
