using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Entities.Exceptions
{
    public class SaveException : Exception
    {
        public SaveException()
        {
        }
        public SaveException(string message)
            : base(message)
        {
        }
        public SaveException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
