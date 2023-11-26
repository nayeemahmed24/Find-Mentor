using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Model.Response
{
    public class QueryResponse<T>
    {
        public QueryResponse() { }
        public QueryResponse(T? response, HttpStatusCode status, string? message)
        {
            this.Result = response;
            this.Status = status;
            Message = message;
        }

        public T Result { get; set; }
        public HttpStatusCode Status { get; set; }
        public string Message { get; set; }
    }
}
