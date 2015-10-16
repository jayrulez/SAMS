using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Validators
{
    public interface IFieldValidator
    {
        bool ValidateField();
    }
}