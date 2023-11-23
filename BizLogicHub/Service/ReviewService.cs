using AutoMapper;
using Model.Dto;
using Model.Dto.Commands;
using Model.Entities;
using Model.Response;
using Repository;
using Service.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ReviewService : IReviewService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public ReviewService(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }

        public async Task<ReviewDto> AddReview(string CorrelationId, ReviewCommandDto reviewDto, string userId)
        {
            Review review = this.mapper.Map<ReviewCommandDto, Review>(reviewDto);
            var res = await dbContext.Reviews.AddAsync(review);
            await dbContext.SaveChangesAsync();
            ReviewDto reviewRes = this.mapper.Map<Review, ReviewDto>(res.Entity);
            return reviewRes;
        }
    }
}
