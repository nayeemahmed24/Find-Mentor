using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dto.Qureies
{
    public class GetUniversityQueryDto
    {
        public string? Name { get; set; }

        public string? Country { get; set; }

        public string? City { get; set; }

        public string? SearchKey { get; set; }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
