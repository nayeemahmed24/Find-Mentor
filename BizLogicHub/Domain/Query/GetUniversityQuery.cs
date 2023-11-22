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
    public class GetUniversityQuery: BaseQuery, IRequest<QueryResponse<List<UniversityDto>>>
    {
        public string? SearchKey { get; set; }
        public string? Name { get; set;}
        public string? Country { get; set; }
        public string? City { get; set; }
    }
}
