using System.Collections.Generic;
using System.Linq;
using DomainBusinessLogic.Exceptions;
using DomainBusinessLogic.Interfaces;
using Entities;

namespace DomainBusinessLogic.Services
{
    public class UserRegisterResolver : IUserRegisterResolver
    {
        private readonly IEnumerable<IUserRegisterStrategy> _strategies;

        public UserRegisterResolver(IEnumerable<IUserRegisterStrategy> strategies)
        {
            _strategies = strategies;
        }

        public IUserRegisterStrategy GetRegistrationStrategy(User user)
        {
            var strategy = _strategies
                .FirstOrDefault(userRegisterStrategy => userRegisterStrategy.UserType == user.GetType());

            if (strategy is null)
            {
                throw new StrategyNotFoundException();
            }
            
            return strategy;
        }
    }
}