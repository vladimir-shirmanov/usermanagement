using System.Collections.Generic;
using System.Threading.Tasks;
using DomainBusinessLogic.Models;
using Entities;

namespace DomainBusinessLogic.Interfaces
{
    public interface IUserManager
    {
        Task RegisterUser(User user);

       Task<List<UserModel>> GetAllUsersAsync(PaginationFilter pager);
    }
}