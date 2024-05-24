using System.Collections.Generic;
using FluentValidation.Results;
using Project_4.Common.ResponseObjects;

namespace Project_4.Business.Extensions
{
    public static class ValidationResultExtension
    {
        public static List<CustomValidationError> ConvertToCustomValidationError(this ValidationResult result)
        {
            var customValidationErrors = new List<CustomValidationError>();
            foreach (var resultError in result.Errors)
            {
                customValidationErrors.Add(new CustomValidationError
                {
                    ErrorMessage = resultError.ErrorMessage,
                    PropertyName = resultError.PropertyName
                });
            }

            return customValidationErrors;
        }
    }
}