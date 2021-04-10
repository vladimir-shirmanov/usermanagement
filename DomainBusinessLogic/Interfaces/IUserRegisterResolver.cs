using Entities;

namespace DomainBusinessLogic.Interfaces
{
    public interface IUserRegisterResolver
    {
        IUserRegisterStrategy GetRegistrationStrategy(User user);
    }
}