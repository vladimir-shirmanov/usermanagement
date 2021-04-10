using System.Collections.Generic;
using Ardalis.Specification;
using DomainBusinessLogic.Exceptions;
using DomainBusinessLogic.Interfaces;
using DomainBusinessLogic.Services;
using DomainBusinessLogic.Strategies;
using Entities;
using Moq;
using NUnit.Framework;

namespace DomainBusinessLogic.Tests
{
    [TestFixture]
    public class UserRegisterResolverTests
    {
        private IUserRegisterResolver _userRegisterResolver;
        
        [SetUp]
        public void Setup()
        {
            var mrGreenRepoStub = Mock.Of<IRepositoryBase<MrGreenUser>>();
            var redBetRepoStub = Mock.Of<IRepositoryBase<RedBetUser>>();
            
            List<IUserRegisterStrategy> strategies = new List<IUserRegisterStrategy>
            {
                new MrGreenRegisterStrategy(mrGreenRepoStub),
                new RedBetRegisterStrategy(redBetRepoStub)
            };
            
            _userRegisterResolver = new UserRegisterResolver(strategies);
        }

        [Test]
        public void GetRegistrationStrategy_PassMrGreenUser_ReturnMrGreenUserRegisterStrategy()
        {
            //Arrange
            User mrGreenUser = new MrGreenUser();
            
            // Act
            var strategy = _userRegisterResolver.GetRegistrationStrategy(mrGreenUser);
            
            //Assert
            Assert.IsInstanceOf(typeof(MrGreenRegisterStrategy), strategy);
        }
        
        [Test]
        public void GetRegistrationStrategy_PassRedBetUser_ReturnRedBetUserRegisterStrategy()
        {
            //Arrange
            User redBetUser = new RedBetUser();
            
            // Act
            var strategy = _userRegisterResolver.GetRegistrationStrategy(redBetUser);
            
            //Assert
            Assert.IsInstanceOf(typeof(RedBetRegisterStrategy), strategy);
        }
        
        [Test]
        public void GetRegistrationStrategy_PassUnknownUser_ThrowsStrategyNotFoundException()
        {
            //Arrange
            User fakeUser = new FakeUser();
            
            //Assert
            Assert.Throws<StrategyNotFoundException>(() 
                => _userRegisterResolver.GetRegistrationStrategy(fakeUser));
        }
    }
}