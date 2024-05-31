

namespace Project_6.Common
{
    public class Response : IResponse
    {
        public string Message { get; set; }
        public ResponseType ResponseType { get; set; }

        public Response(ResponseType responseType)
        {
            ResponseType = responseType;
        }
        public Response(ResponseType responseType,string message)
        {
            ResponseType = responseType;
            Message = message;
        }
    }
    public enum ResponseType
    {
        Succes=0,
        ValidationError=1,
        NotFound=2,
    }
}
