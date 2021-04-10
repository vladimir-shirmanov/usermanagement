using System;
using System.Threading.Tasks;
using Ardalis.Specification;
using DomainBusinessLogic.Exceptions;
using DomainBusinessLogic.Interfaces;
using Entities;

namespace DomainBusinessLogic.Strategies
{
    public class MrGreenRegisterStrategy : IUserRegisterStrategy
    {
        private readonly IRepositoryBase<MrGreenUser> _userRepo;

        public MrGreenRegisterStrategy(IRepositoryBase<MrGreenUser> userRepo)
        {
            _userRepo = userRepo;
        }

        public Task RegisterUserAsync(User user)
        {
            if (user is MrGreenUser mrGreenUser)
            {
                return _userRepo.AddAsync(mrGreenUser);
            }

            throw new WrongUserParameterTypeException(nameof(MrGreenRegisterStrategy));
        }

        public Type UserType { get; } = typeof(MrGreenUser);
    }
}