using System.Collections.Generic;

namespace Project_4.Common.ResponseObjects
{
    public class Response<T> : Response,IResponse<T>
    {
        public T Data { get; set; }
        
        public Response(ResponseType responseType,T data) :base(responseType)
        {
            Data = data;
        }

        public Response(ResponseType responseType, T data,List<CustomValidationError> errors) : base(responseType)
        {
            Data = data;
            ValidationErrors = errors;
        }

        public Response(ResponseType responseType, string message) :base(responseType,message)
        {
            
        }

        public List<CustomValidationError> ValidationErrors { get; set; }
    }
}