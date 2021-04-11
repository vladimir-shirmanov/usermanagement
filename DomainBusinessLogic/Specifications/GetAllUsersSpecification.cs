using System;
using Ardalis.Specification;
using DomainBusinessLogic.Models;
using Entities;

namespace DomainBusinessLogic.Specifications
{
    public sealed class GetAllUsersSpecification : PaginationSpecification<User, UserModel>
    {
        public GetAllUsersSpecification(PaginationFilter filter) : base(filter)
        {
            Query.Include(u => u.Address);
            Query.Select(u => new UserModel
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                Street = u.Address.Street,
                ZipCode = u.Address.ZipCode,
                BuildingNumber = u.Address.BuildingNumber,
                UserId = u.Id,
                FavoriteFootballTeam = u is RedBetUser ? ((RedBetUser)u).FavoriteFootballTeam : string.Empty,
                PersonalNumber = u is MrGreenUser ? ((MrGreenUser)u).PersonalNumber : string.Empty,
            });
        }
    }
}