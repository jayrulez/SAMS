using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Helpers
{
    public class Response<T> : IResponse<T>
    {
        public Response()
        {
        }

        public T Result { get; set; }

        public Error Error { get; set; }

        public bool IsSuccessful
        {
            get
            {
                return Error == null ? true : false;
            }
        }
    }
}