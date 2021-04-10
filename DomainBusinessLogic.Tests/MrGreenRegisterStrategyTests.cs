using Ardalis.Specification;
using DomainBusinessLogic.Exceptions;
using DomainBusinessLogic.Strategies;
using Entities;
using Moq;
using NUnit.Framework;

namespace DomainBusinessLogic.Tests
{
    [TestFixture]
    public class MrGreenRegisterStrategyTests
    {
        private MrGreenRegisterStrategy _registerStrategy;

        private IRepositoryBase<MrGreenUser> _mockRepository;
        
        [SetUp]
        public void Setup()
        {
            _mockRepository = Mock.Of<IRepositoryBase<MrGreenUser>>();
            _registerStrategy = new MrGreenRegisterStrategy(_mockRepository);
        }

        [Test]
        public void MrGreenRegisterStrategy_PassMrGreenUserToRegisterUserAsync_CalledRepositoryAddAsync()
        {
            // Arrange
            var user = new MrGreenUser();
            
            // Act
            _registerStrategy.RegisterUserAsync(user);
            
            // Assert
            Mock.Get(_mockRepository).Verify(repo => repo.AddAsync(user), Times.Once);
        }
        
        [Test]
        public void RedBetRegisterStrategy_PassWrongUserTypeToRegisterUserAsync_ThrowWrongUserParameterTypeException()
        {
            // Arrange
            var user = new RedBetUser();
            
            // Assert
            Assert.Throws<WrongUserParameterTypeException>(() => _registerStrategy.RegisterUserAsync(user));
        }
    }
}