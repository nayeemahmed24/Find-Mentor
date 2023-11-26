using Model.Dto;
using Model.Dto.Commands;
using Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstractions
{
    public interface IReviewService
    {
        public Task<ReviewDto> AddReview(string CorrelationId, ReviewCommandDto reviewDto, string userId);
    }
}
