using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Helpers
{
    public interface IResponse<T>
    {
        T Result { get; set; }
        Error Error { get; set; }
        bool IsSuccessful { get; }
    }
}