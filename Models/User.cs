
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class User
    {
        public long Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }
    }
}
