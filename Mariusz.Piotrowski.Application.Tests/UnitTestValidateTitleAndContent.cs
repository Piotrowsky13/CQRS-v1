using Mariusz.Piotrowski.Application.Articles.Commands.CreateArticle;
using Mariusz.Piotrowski.Application.Categories.Commands.CreateCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mariusz.Piotrowski.Application.Tests
{
    public class UnitTestValidateTitleAndContent
    {
        private readonly CreateArticleCommandValidator _validator = new();

        [Fact]
        public void When_Title_Is_Empty_Should_Have_Error()
        {
            // Arrange
            var command = new CreateArticleCommand
            {
                Title = "",
                Content = "Valid content here",
                Author = "author",
                CategoryId = Guid.NewGuid()
            };

            // Act
            var result = _validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "Title");
        }

        [Fact]
        public void When_Title_Is_Valid_Should_Pass()
        {
            // Arrange
            var command = new CreateArticleCommand
            {
                Title = "Tech",
                Content = "Valid content here",
                Author = "author",
                CategoryId = Guid.NewGuid()
            };

            // Act
            var result = _validator.Validate(command);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void When_Content_Is_Less_Than_10_Characters_Should_Have_Error()
        {
            // Arrange
            var command = new CreateArticleCommand
            {
                Title = "Valid Title",
                Content = "short",
                Author = "author",
                CategoryId = Guid.NewGuid()
            };

            // Act
            var result = _validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "Content");
        }

        [Fact]
        public void When_Content_Is_Valid_Should_Pass()
        {
            // Arrange
            var command = new CreateArticleCommand
            {
                Title = "Valid Title",
                Content = "This content is definitely longer than 10 characters.",
                Author = "author",
                CategoryId = Guid.NewGuid()
            };

            // Act
            var result = _validator.Validate(command);

            // Assert
            Assert.True(result.IsValid);
        }

    }
}
