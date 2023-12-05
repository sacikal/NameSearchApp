using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NameSearchApp.Controllers;
using NameSearchApp.Domain;
using NameSearchApp.Services;
using NUnit.Framework;
using System.Collections.Generic;

namespace NameSearchApp.Tests.Controllers
{
    [TestFixture]
    public class SearchControllerTests
    {
        [Test]
        public void Get_WithValidSearchTerm_ReturnsOkResult()
        {
            // Arrange
            var searchServiceMock = new Mock<ISearchService>(MockBehavior.Strict);
            searchServiceMock.Setup(x => x.Search("Valid"))
                .Returns(new List<Person> { new Person { Id = 1, FirstName = "Valid", LastName = "Person" } });

            var controller = new SearchController(searchServiceMock.Object);

            // Act
            var result = controller.Get("Valid").Result as OkObjectResult;

            // Assert
            var persons = result?.Value as List<Person>;
            persons.Should().HaveCount(1);

            result.Should().BeOfType<List<Person>>()
                  .Which.Should().Contain(person => person.FirstName == "Valid" && person.LastName == "Person");
        }

        [Test]
        public void Get_WithEmptySearchTerm_ReturnsBadRequestResult()
        {
            // Arrange
            var searchServiceMock = new Mock<ISearchService>();
            var controller = new SearchController(searchServiceMock.Object);

            // Act
            var result = controller.Get("");

            // Assert
            result.Result.Should().BeOfType<BadRequestObjectResult>()
                .Which.Value.Should().Be("Please provide a search term");
        }

    }
}
