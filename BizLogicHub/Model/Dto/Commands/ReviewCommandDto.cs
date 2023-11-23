using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dto.Commands
{
    public class ReviewCommandDto
    {
        public ReviewCommandDto(string mentorId, string review, double rating)
        {
            this.MentorId = mentorId;
            this.Review = review;
            this.Rating = rating;
        }

        public string MentorId { get; set; }
        public string? Review { get; set; }
        public double Rating { get; set; }
    }
}
