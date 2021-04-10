using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Address : BaseEntity
    {
        public string Street { get; set; }

        public string ZipCode { get; set; }

        public int BuildingNumber { get; set; }

        public User User { get; set; }

        [ForeignKey(nameof(UserId))]
        public Guid UserId { get; set; }
    }
}