using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Mariusz.Piotrowski.Application.Common.Exceptions
{
    public class BadRequestException : Exception
    {
        public IDictionary<string, string[]> ValidationErrors { get; }

        public BadRequestException(string message)
            : base(message)
        {
            ValidationErrors = new Dictionary<string, string[]>();
        }

        public BadRequestException(string message, ValidationResult validationResult)
            : base(message)
        {
            ValidationErrors = validationResult.Errors
                .GroupBy(e => e.PropertyName)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(e => e.ErrorMessage).ToArray()
                );
        }
    }
}
