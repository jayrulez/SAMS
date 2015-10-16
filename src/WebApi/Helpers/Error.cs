using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Helpers
{
    public class Error
    {
        internal string _message;
        internal Exception _exception;

        public Error(string message)
        {
            _message = message;
        }

        public Error(Exception exception)
        {
            Exception = exception;
        }

        public string Message
        {
            get { return _message; }
            private set
            {
                _message = value;
            }
        }

        public Exception Exception
        {
            get { return _exception; }
            private set
            {
                _exception = value;
            }
        }

        public override string ToString()
        {
            return Message;
        }
    }
}