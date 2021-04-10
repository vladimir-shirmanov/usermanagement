using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class MrGreenUser : User
    {
        [Required]
        public string PersonalNumber { get; set; }
    }
}