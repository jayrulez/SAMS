using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FMS.Api.Infrastructure.Common
{
    public class DataManipulatonResult<T>
    {
        public DataManipulatonResult(bool isSuccessful, T key)
        {
            IsSuccessful = isSuccessful;
            Key = key;
        }

        public bool IsSuccessful
        {
            get;
        }
        public T Key
        {
            get;
        }
    }
}