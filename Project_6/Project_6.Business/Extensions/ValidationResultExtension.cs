using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using Project_6.Common;

namespace Project_6.Business.Extensions
{
    public static class ValidationResultExtension
    {
        public static List<CustomValidationError> ConvertToCustomValidationError(this ValidationResult validationResult)
        {
            return validationResult.Errors.Select(resultError => new CustomValidationError() { ErrorMessage = resultError.ErrorMessage, PropertyName = resultError.PropertyName }).ToList();
        }
    }
}