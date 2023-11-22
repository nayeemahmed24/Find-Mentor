using Domain.Query;
using MediatR;
using Model.Dto;
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
    public class GetMentorDetailsQueryHandler : IRequestHandler<GetMentorDetailsQuery, QueryResponse<MentorDto>>
    {
        private readonly IMentorService _mentorService;
        public GetMentorDetailsQueryHandler(IMentorService mentorService)
        {
            this._mentorService = mentorService;
        }
        public async Task<QueryResponse<MentorDto>> Handle(GetMentorDetailsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                string correlationId = Guid.NewGuid().ToString();   
                MentorDto mentorDto = await _mentorService.GetMentorDetails(correlationId, request.MentorId);
                return new QueryResponse<MentorDto>(mentorDto, HttpStatusCode.OK, null);
            }
            catch(Exception ex) 
            {
                return new QueryResponse<MentorDto>(null, HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
