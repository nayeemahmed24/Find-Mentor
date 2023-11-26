using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dto
{
    public class MentorDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ProfileDescription { get; set; }
        public decimal Rating { get; set; }
        public virtual UniversityDto University { get; set; }
        public virtual ICollection<ReviewDto> Reviews { get; set; }
    }
}
