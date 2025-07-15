using FluentValidation;
using Mariusz.Piotrowski.Application.Articles.Commands.CreateArticle;
using Mariusz.Piotrowski.Application.Categories.Commands.CreateCategory;
using Mariusz.Piotrowski.Application.Common.Helpers;
using Mariusz.Piotrowski.Application.Interfaces.IRepository;
using Mariusz.Piotrowski.Domain.Entities;
using MediatR;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
namespace Mariusz.Piotrowski.Application.Tests
{
    public class UnitTestValidateCategoryTests
    {
        private readonly CreateCategoryCommandValidator _validator = new();

        [Fact]
        public void Should_Have_Error_When_Name_Is_Empty()
        {
            // Arrange
            var command = new CreateCategoryCommand { Name = "" };

            // Act
            var result = _validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "Name");
        }

        [Fact]
        public void Should_Pass_When_Name_Is_Valid()
        {
            var command = new CreateCategoryCommand { Name = "Tech" };
            var result = _validator.Validate(command);

            Assert.True(result.IsValid);
        }

    }
}
