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
    public class AddUniversityCommandHandler : IRequestHandler<AddUniversityCommand, CommandResponse>
    {
        private readonly IMapper mapper;
        private readonly IUniversityService universityService;
        public AddUniversityCommandHandler(IMapper mapper, IUniversityService universityService)
        {
            this.mapper = mapper;
            this.universityService = universityService;
        }

        public async Task<CommandResponse> Handle(AddUniversityCommand request, CancellationToken cancellationToken)
        {
            try
            {
                UniversityCommandDto commandDto = this.mapper.Map<AddUniversityCommand, UniversityCommandDto>(request);
                UniversityDto universityDto = await this.universityService.AddUniversity(request.CorrelationId, commandDto);
                return new CommandResponse(universityDto, HttpStatusCode.OK, null);
            }
            catch (Exception ex) 
            {
                return new CommandResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            
            throw new NotImplementedException();
        }
    }
}
