using MediatR;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace UseCases.Requests
{
    public class SupplierGetRequest : IRequest<IList<SupplierModel>>
    {
        public String Name { get; set; }
        public String Sort { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
