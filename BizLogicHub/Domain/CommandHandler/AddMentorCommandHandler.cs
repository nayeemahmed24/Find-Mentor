using AutoMapper;
using Domain.Command;
using MediatR;
using Model.Dto;
using Model.Dto.Commands;
using Model.Response;
using Service.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CommandHandler
{
    public class AddMentorCommandHandler : IRequestHandler<AddMentorCommand, CommandResponse>
    { 
        private readonly IMapper mapper;
        private readonly IUniversityService universityService;
        private readonly IMentorService mentorService;
        public AddMentorCommandHandler(IMapper mapper, IUniversityService universityService, IMentorService mentorService)
        {
            this.mapper = mapper;
            this.universityService = universityService;
            this.mentorService = mentorService;
        }

        public async Task<CommandResponse> Handle(AddMentorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                MentorCommandDto commandDto = this.mapper.Map<AddMentorCommand, MentorCommandDto>(request);
                UniversityDto university = await this.universityService.GetUniversityDetails(request.CorrelationId, request.UniversityId);

                if(university == null) 
                {
                    return new CommandResponse(HttpStatusCode.BadRequest, "University in not found");
                }

                MentorDto mentorDto = await this.mentorService.AddMentor(request.CorrelationId, commandDto);

                return new CommandResponse(mentorDto, HttpStatusCode.OK, null);
            }
            catch(Exception ex)
            {
                return new CommandResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
