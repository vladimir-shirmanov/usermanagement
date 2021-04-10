using Ardalis.Specification;
using DomainBusinessLogic.Exceptions;
using DomainBusinessLogic.Strategies;
using Entities;
using Moq;
using NUnit.Framework;

namespace DomainBusinessLogic.Tests
{
    [TestFixture]
    public class RedBetRegisterStrategyTests
    {
        private RedBetRegisterStrategy _registerStrategy;

        private IRepositoryBase<RedBetUser> _mockRepository;
        
        [SetUp]
        public void Setup()
        {
            _mockRepository = Mock.Of<IRepositoryBase<RedBetUser>>();
            _registerStrategy = new RedBetRegisterStrategy(_mockRepository);
        }

        [Test]
        public void RedBetRegisterStrategy_PassRedBetUserToRegisterUserAsync_CalledRepositoryAddAsync()
        {
            // Arrange
            var user = new RedBetUser();
            
            // Act
            _registerStrategy.RegisterUserAsync(user);
            
            // Assert
            Mock.Get(_mockRepository).Verify(repo => repo.AddAsync(user), Times.Once);
        }
        
        [Test]
        public void RedBetRegisterStrategy_PassWrongUserTypeToRegisterUserAsync_ThrowWrongUserParameterTypeException()
        {
            // Arrange
            var user = new MrGreenUser();
            
            // Assert
            Assert.Throws<WrongUserParameterTypeException>(() => _registerStrategy.RegisterUserAsync(user));
        }
    }
}