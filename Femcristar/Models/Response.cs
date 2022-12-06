using System.Net;

namespace AppEmergencia.Models
{
    public class Response
    {
        public bool IsSuccess
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public object Result
        {
            get;
            set;
        }

        public HttpStatusCode StatusCode
        {
            get;
            set;
        }
    }
}
