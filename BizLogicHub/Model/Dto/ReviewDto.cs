using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dto
{
    public class ReviewDto
    {
        public string Id { get; set; }
        public string ReviewText { get; set; }
        public int Rating { get; set; }
    }
}
