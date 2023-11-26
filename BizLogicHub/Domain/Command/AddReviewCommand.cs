using MediatR;
using Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Command
{
    public  class AddReviewCommand: BaseCommand, IRequest<CommandResponse>
    {
        public string UserId { get; set; }
        public string MentorId { get; set; }
        public string ReviewText { get; set; }
        public int Rating { get; set; }

    }
}
