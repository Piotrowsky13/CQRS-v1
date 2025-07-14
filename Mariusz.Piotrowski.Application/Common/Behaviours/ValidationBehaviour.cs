using FluentValidation;
using FluentValidation.Results;
using Mariusz.Piotrowski.Application.Common.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mariusz.Piotrowski.Application.Common.Behaviours
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : class
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly ILogger<ValidationBehavior<TRequest, TResponse>> _logger;

        public ValidationBehavior(
            IEnumerable<IValidator<TRequest>> validators,
            ILogger<ValidationBehavior<TRequest, TResponse>> logger)
        {
            _validators = validators;
            _logger = logger;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(
                    _validators.Select(v => v.ValidateAsync(context, cancellationToken)));

                var failures = validationResults
                    .SelectMany(r => r.Errors)
                    .Where(f => f != null)
                    .ToList();

                if (failures.Any())
                {
                    // Log validation errors
                    foreach (var failure in failures)
                    {
                        _logger.LogWarning("Validation failure in {RequestType}: {PropertyName} failed validation. Error: {ErrorMessage}",
                            typeof(TRequest).Name,
                            failure.PropertyName,
                            failure.ErrorMessage);
                    }

                    throw new BadRequestException("Validation failed", new ValidationResult(failures));
                }
            }

            return await next();
        }
    }
}
