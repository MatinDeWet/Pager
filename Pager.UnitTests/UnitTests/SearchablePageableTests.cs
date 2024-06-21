using Pager.UnitTests.Models;

namespace Pager.UnitTests.UnitTests
{
    public class SearchablePageableTests
    {

        [Fact]
        public void SearchablePageableRequest_WhenSearchTextIsGiven_ShouldSeperateItIntoStringList()
        {
            // Arrange

            var pageable = new ClientSearchablePageableDto
            {
                SearchTerms = "One Two Three"
            };

            // Act
            var result = pageable.GetSearchTerms();

            // Assert
            var items = new List<string> { "One", "Two", "Three" };
            Assert.Equal(items, result);
        }
    }
}
