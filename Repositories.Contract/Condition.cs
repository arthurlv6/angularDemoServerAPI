using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Contract
{
    public class Condition
    {
        public String Name { get; set; }
        public String Sort { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
