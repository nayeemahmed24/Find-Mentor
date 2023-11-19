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
        public CommandResponse(object? response, bool isSuccess, string? msg) { 
            this.Result = response;
            this.IsSuccess = isSuccess;
            this.Message = msg;
        }

        public object Result { get; set; }
        public bool IsSuccess { get; set; }

        public string Message { get; set; }
    }
}
