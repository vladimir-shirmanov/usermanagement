using System;

namespace DomainBusinessLogic.Models
{
    public class UserModel
    {
        public Guid UserId { get; set; }
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Street { get; set; }

        public string ZipCode { get; set; }

        public int BuildingNumber { get; set; }

        public string FavoriteFootballTeam { get; set; }

        public string PersonalNumber { get; set; }
    }
}