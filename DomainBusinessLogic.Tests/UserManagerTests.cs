using Ardalis.Specification;
using DomainBusinessLogic.Interfaces;
using DomainBusinessLogic.Services;
using Entities;
using Moq;
using NUnit.Framework;

namespace DomainBusinessLogic.Tests
{
    [TestFixture]
    public class UserManagerTests
    {
        private IUserManager _userManager;

        private IUserRegisterStrategy _mockUserStrategy;

        private IRepositoryBase<User> _mockRepository;
        
        [SetUp]
        public void Setup()
        {
            _mockRepository = Mock.Of<IRepositoryBase<User>>();
            _mockUserStrategy = Mock.Of<IUserRegisterStrategy>();
            var mockUserRegisterResolver = new Mock<IUserRegisterResolver>();
            mockUserRegisterResolver.Setup(m => m.GetRegistrationStrategy(It.IsAny<User>()))
                .Returns(_mockUserStrategy);

            _userManager = new UserManager(mockUserRegisterResolver.Object, _mockRepository);
        }

        [Test]
        public void UserManager_RegisterUser_CalledUserRegisterStrategyOnce()
        {
            // Arrange
            var user = It.IsAny<User>();
            
            //Act
            _userManager.RegisterUser(user);
            
            //Assert
            Mock.Get(_mockUserStrategy).Verify(strategy => strategy.RegisterUserAsync(user), Times.Once);
        }

        [Test]
        public void UserManager_GetAllUsers_CalledRepositoryToListAsyncOnce()
        {
            // Act
            _userManager.GetAllUsersAsync();
            
            // Assert
            Mock.Get(_mockRepository).Verify(repo => repo.ListAsync(), Times.Once);
        }
    }
}