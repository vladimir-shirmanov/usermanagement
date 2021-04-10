using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace DomainBusinessLogic.Interfaces
{
    public interface IUserManager
    {
        Task RegisterUser(User user);

       Task<List<User>> GetAllUsersAsync();
    }
}