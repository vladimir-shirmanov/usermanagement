using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class RedBetUser : User
    {
        [Required]
        public string FavoriteFootballTeam { get; set; }
    }
}