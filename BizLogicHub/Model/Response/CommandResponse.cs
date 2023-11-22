using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Model.Response
{
    public class CommandResponse
    {
        public CommandResponse() { }
        public CommandResponse(object? response, HttpStatusCode status, string? msg) { 
            this.Result = response;
            this.Status = status;
            this.Message = msg;
        }

        public object Result { get; set; }
        public HttpStatusCode Status { get; set; }

        public string Message { get; set; }
    }
}
