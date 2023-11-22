using MediatR;
using Model.Dto;
using Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Query
{
    public class GetMentorDetailsQuery: IRequest<QueryResponse<MentorDto>>
    {
        public string MentorId { get; set; }
    }
}
