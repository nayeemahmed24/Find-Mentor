using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Mentor: BaseEntity
    {
        public Mentor()
        {
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }

        [Required]
        public string Name {  get; set; }
        [Required]
        public string ProfileDescription { get; set; }
        [DefaultValue(0.00)]
        public decimal Rating { get; set; }
        [ForeignKey("University")]
        public string UniversityId { get; set; }

        public virtual University University { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

    }
}
