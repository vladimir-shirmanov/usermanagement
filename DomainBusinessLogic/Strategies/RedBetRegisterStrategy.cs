using System;
using System.Threading.Tasks;
using Ardalis.Specification;
using DomainBusinessLogic.Exceptions;
using DomainBusinessLogic.Interfaces;
using Entities;

namespace DomainBusinessLogic.Strategies
{
    public class RedBetRegisterStrategy : IUserRegisterStrategy
    {
        private readonly IRepositoryBase<RedBetUser> _userRepo;

        public RedBetRegisterStrategy(IRepositoryBase<RedBetUser> userRepo)
        {
            _userRepo = userRepo;
        }

        public Task RegisterUserAsync(User user)
        {
            if (user is RedBetUser mrGreenUser)
            {
                return _userRepo.AddAsync(mrGreenUser);
            }

            throw new WrongUserParameterTypeException(nameof(RedBetRegisterStrategy));
        }

        public Type UserType { get; } = typeof(RedBetUser);
    }
}