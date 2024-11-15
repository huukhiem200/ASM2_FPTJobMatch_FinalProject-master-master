using System.ComponentModel.DataAnnotations;

namespace ASM2_FPTJobMatch.Models
{
    public class JobSeeker
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public string StreetAddress { get; set; }

        [Required]
        public string City { get; set; }
    }
}
