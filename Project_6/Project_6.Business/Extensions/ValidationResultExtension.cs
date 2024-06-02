using System.Collections.Generic;
using FluentValidation.Results;
using Project_6.Common;

namespace Project_6.Business.Extensions
{
    public static class ValidationResultExtension
    {
        public static List<CustomValidationError> ConvertToCustomValidationError(this ValidationResult validationResult)
        {
            var errors = new List<CustomValidationError>();
            foreach (var resultError in validationResult.Errors)
            {
                errors.Add(new()
                {
                    
                    ErrorMessage = resultError.ErrorMessage,
                    PropertyName = resultError.PropertyName
               
                });
            }

            return errors;
        }
    }
}