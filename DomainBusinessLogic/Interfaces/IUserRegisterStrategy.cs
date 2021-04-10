using System;
using System.Threading.Tasks;
using Entities;

namespace DomainBusinessLogic.Interfaces
{
    public interface IUserRegisterStrategy
    {
        Task RegisterUserAsync(User user);
        
        Type UserType { get; }
    }
}