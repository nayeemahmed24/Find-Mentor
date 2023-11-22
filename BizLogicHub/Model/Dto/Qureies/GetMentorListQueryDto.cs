using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dto.Qureies
{
    public class GetMentorListQueryDto
    {
        public string? Name { get; set; }

        public string? UniversityName { get; set; }
        public string? SearchKey { get; set; }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
