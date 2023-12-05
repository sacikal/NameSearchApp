using FluentAssertions;
using NameSearchApp.Services;
using NUnit.Framework;

namespace NameSearchApp.Tests.Services
{
    [TestFixture]
    public class SearchServiceTests
    {
        private ISearchService searchService;

        [SetUp]
        public void SetUp()
        {
            searchService = new SearchService("Data/data.json");
        }

        [Test]
        public void Search_WithJames_ReturnsJamesKubuAndJamesPfeffer()
        {
            // Act
            var results = searchService.Search("James");

            // Assert
            results.Should().Contain(s=>s.FirstName == "James" && s.LastName == "Kubu")
                        .And.Contain(d=>d.FirstName == "James" && d.LastName == "Pfeffer");

        }

        [Test]
        public void Search_WithJam_ReturnsJamesKubuJamesPfefferAndChalmersLongfut()
        {
            // Act
            var results = searchService.Search("Jam");

            // Assert
            results.Should().HaveCount(3)
                .And.Contain(person => person.FirstName == "James" && person.LastName == "Kubu")
                .And.Contain(person => person.FirstName == "James" && person.LastName == "Pfeffer")
                .And.Contain(person => person.FirstName == "Chalmers" && person.LastName == "Longfut");
        }

        [Test]
        public void Search_WithKateySoltan_ReturnsKateySoltanOnly()
        {
            // Act
            var results = searchService.Search("Katey Soltan");

            // Assert
            results.Should().HaveCount(1)
                   .And.Contain(person => person.FirstName == "Katey" && person.LastName == "Soltan");           
        }

        [Test]
        public void Search_WithJasmineDuncan_ReturnsNoResults()
        {
            // Act
            var results = searchService.Search("Jasmine Duncan");

            // Assert
            results.Should().BeEmpty();
        }

        [Test]
        public void Search_WithEmptyInput_ReturnsNoResults()
        {
            // Act
            var results = searchService.Search("");

            // Assert
            results.Should().BeEmpty();
        }
    }
}