using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Validators
{
    public abstract class BaseFieldValidator
    {
        public bool Required;
        public IEnumerable<string> Errors;
    }
}