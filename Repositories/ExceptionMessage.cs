using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Repositories
{
    public enum ExceptionMessage
    {
        [Description("Id didn't exist.")]
        ValidationIdExceptionMessage,
        [Description("Failed to save.")]
        SaveExceptionMessage
    }
}
