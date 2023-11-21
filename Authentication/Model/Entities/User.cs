using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    public class User: BaseEntity
    {
        public User() 
        {
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
