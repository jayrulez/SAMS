using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FMS.Api.Infrastructure.Common
{
    public class DataQueryResult<T>
    {
        public DataQueryResult(T data, int count)
        {
            Data = data;
            Count = count;
        }

        public T Data { get; }
        public int Count { get; }
    }
}