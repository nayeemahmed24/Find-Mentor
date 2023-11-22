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
    public class GetMentorListQuery: BaseQuery, IRequest<QueryResponse<List<MentorDto>>>
    {
        public string? SearchKey { get; set; }
        public string? Name { get; set; }
        public string? UniversityName { get; set; }
    }
}
