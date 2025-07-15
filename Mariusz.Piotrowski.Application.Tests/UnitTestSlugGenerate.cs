using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Mariusz.Piotrowski.Application.Common.Helpers;
using Mariusz.Piotrowski.Domain.Entities;
using Mariusz.Piotrowski.Application.Interfaces.IRepository;

namespace Mariusz.Piotrowski.Application.Tests
{
    public class GenerateSlugHelperTests
    {
        [Fact]
        public async Task GenerateSlug_GenerateFunctionality_Test()
        {
            // Arrange
            var mockRepo = new Mock<IRepository<Article>>();
            mockRepo.Setup(r => r.FindAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<Article, bool>>>()))
                .ReturnsAsync(new List<Article>());

            string title = "Test Title";
            string expectedSlug = "test-title";

            // Act
            var result = await mockRepo.Object.GenerateSlugAsync(title);

            // Assert
            Assert.Equivalent(expectedSlug, result);
        }

        [Fact]
        public async Task GenerateSlug_GenerateFunctionality_If_Duplicate_Test()
        {
            // Arrange
            var mockRepo = new Mock<IRepository<Article>>();
            var existingArticles = new List<Article>
            {
                new Article("Test Title", "", "", "test-title" ,Domain.Enums.Status.Draft, Guid.NewGuid()),
                new Article("Test Title", "", "", "test-title-1", Domain.Enums.Status.Draft, Guid.NewGuid()),
                new Article("Test Title", "", "", "test-title-2", Domain.Enums.Status.Draft, Guid.NewGuid())
            };

            mockRepo.Setup(r => r.FindAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<Article, bool>>>()))
                .ReturnsAsync(existingArticles);

            string title = "Test Title";
            string expectedSlug = "test-title-3";

            // Act
            var result = await mockRepo.Object.GenerateSlugAsync(title);

            // Assert
            Assert.Equal(expectedSlug, result);
        }


    }
}