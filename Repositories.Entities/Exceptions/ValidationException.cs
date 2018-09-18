using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Entities.Exceptions
{
    public class ValidationExistException : Exception
    {
        public ValidationExistException()
        {
        }
        public ValidationExistException(string message)
            : base(message)
        {
        }
        public ValidationExistException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
