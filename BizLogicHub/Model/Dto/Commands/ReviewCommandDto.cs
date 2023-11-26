using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dto.Commands
{
    public class ReviewCommandDto
    {
        public ReviewCommandDto() { }
        public ReviewCommandDto(string mentorId, string review, double rating)
        {
            this.MentorId = mentorId;
            this.ReviewText = review;
            this.Rating = rating;
        }
        public string UserId { get; set; }
        public string MentorId { get; set; }
        public string? ReviewText { get; set; }
        public double Rating { get; set; }
    }
}
