using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.Specification;
using DomainBusinessLogic.Interfaces;
using Entities;

namespace DomainBusinessLogic.Services
{
    public class UserManager : IUserManager
    {
        private readonly IUserRegisterResolver _userResolver;

        private readonly IRepositoryBase<User> _userRepository;

        public UserManager(IUserRegisterResolver userResolver, IRepositoryBase<User> userRepository)
        {
            _userResolver = userResolver;
            _userRepository = userRepository;
        }

        public Task RegisterUser(User user)
        {
            var strategy = _userResolver.GetRegistrationStrategy(user);

            return strategy.RegisterUserAsync(user);
        }

        public Task<List<User>> GetAllUsersAsync()
        {
            return _userRepository.ListAsync();
        }
    }
}