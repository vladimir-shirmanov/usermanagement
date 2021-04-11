using System;
using System.Collections.Generic;
using System.Linq;
using Ardalis.Specification;
using DomainBusinessLogic.Models;
using DomainBusinessLogic.Specifications;
using Entities;
using NUnit.Framework;

namespace DomainBusinessLogic.Tests.SpecificationTests
{
    [TestFixture]
    public class GetAllUsersSpecificationTests
    {
        private List<User> users = new();
        
        [SetUp]
        public void Setup()
        {
            for (int i = 0; i < 100; i++)
            {
                users.Add(new FakeUser() {FirstName = i.ToString(), Address = new Address(), Id = Guid.NewGuid() });
            }
        }

        [Test]
        public void GetAllUsersSpecification_PassPageOneAndSizeTen_ReturnsFirstTenItems()
        {
            //Arrange
            User firstUser = users.OrderBy(u => u.Id).ToList()[0];
            PaginationFilter filter = new PaginationFilter {Page = 1, PageSize = 10};
            GetAllUsersSpecification spec = new GetAllUsersSpecification(filter);
            var evaluator = new InMemorySpecificationEvaluator();
            
            //Act
            var result = evaluator.Evaluate(users, spec).ToList();
            
            //Assert
            Assert.AreEqual(filter.PageSize, result.Count);
        }
    }
}