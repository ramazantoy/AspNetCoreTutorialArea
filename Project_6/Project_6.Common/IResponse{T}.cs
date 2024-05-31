using System.Collections.Generic;

namespace Project_6.Common
{
    public interface IResponse<T> : IResponse
    {
        T Data { get; set; }

        List<CustomValidationError> ValidationErrors { get; set; }
    }
}