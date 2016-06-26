using System.ComponentModel.DataAnnotations;

namespace UserResource.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(128)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(128)]
        public string LastName { get; set; }
        public UserContactInformationViewModel UserContactInformation { get; set; }
    }
}