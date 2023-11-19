using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Response
{
    public class QueryResponse<T>
    {
        public QueryResponse() { }
        public QueryResponse(T response, bool isSuccess)
        {
            this.Result = response;
            this.IsSuccess = isSuccess;
            if(isSuccess)
            {
                Type valueType = Result.GetType();
                if(valueType.IsArray)
                {
                    TotalCount = (Result as Array).Length;
                }
            }
        }

        public T Result { get; set; }
        public bool IsSuccess { get; set; }

        public int TotalCount { get; set; }
    }
}
