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
    public class GetMentorListHandler : IRequestHandler<GetMentorListQuery, QueryResponse<List<MentorDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IMentorService _mentorService; 

        public GetMentorListHandler(IMapper mapper, IMentorService mentorService)
        {
            _mapper = mapper;
            _mentorService = mentorService;
        }
        public async Task<QueryResponse<List<MentorDto>>> Handle(GetMentorListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                GetMentorListQueryDto queryDto = _mapper.Map<GetMentorListQuery, GetMentorListQueryDto>(request);
                List<MentorDto> mentorDtos = await _mentorService.GetMentorDtos(request.CorrelationId, queryDto);
                return new QueryResponse<List<MentorDto>>(mentorDtos, HttpStatusCode.OK, null);
            }
            catch(Exception ex) 
            {
                return new QueryResponse<List<MentorDto>>(null, HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
