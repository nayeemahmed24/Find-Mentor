using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Review: BaseEntity
    {
        public Review() 
        {
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }

        [ForeignKey("Mentor")]
        public string MentorId { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        [Required]
        public string ReviewText {  get; set; }
        [Required]
        public int Rating { get; set; }
        public virtual Mentor Mentor { get; set; }
        [Required]
        public virtual User User { get; set; }

    }
}
