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
    public class AddReviewCommandHandler : IRequestHandler<AddReviewCommand, CommandResponse>
    {
        private readonly IMentorService mentorService;
        private readonly IReviewService reviewService;
        private readonly IMapper mapper;
        public AddReviewCommandHandler(IMentorService mentorService, IReviewService reviewService, IMapper mapper)
        {
            this.mentorService = mentorService;
            this.reviewService = reviewService;
            this.mapper = mapper;
        }

        public async Task<CommandResponse> Handle(AddReviewCommand request, CancellationToken cancellationToken)
        {
            try
            { 
                MentorDto mentorDto = await this.mentorService.GetMentorDetails(request.CorrelationId, request.MentorId);
                if (mentorDto == null)
                {
                    return new CommandResponse(null, HttpStatusCode.BadRequest, "Mentor is not found.");
                }

                ReviewCommandDto reviewCommandDto = this.mapper.Map<AddReviewCommand, ReviewCommandDto>(request);
                ReviewDto reviewDto = await this.reviewService.AddReview(request.CorrelationId, reviewCommandDto, request.UserId); // TODO to add UserId
                return new CommandResponse(reviewDto, HttpStatusCode.OK, null);
            }
            catch (Exception ex) 
            {
                return new CommandResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }
    }
}
