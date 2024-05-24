using System.Collections.Generic;

namespace Project_4.Common.ResponseObjects
{
    public interface IResponse<T> : IResponse
    { 
        T Data { get; set; }
        
        List<CustomValidationError> ValidationErrors { get; set; }
    }
}