using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace UseCases.Requests
{
    public class SupplierTotalRequest : IRequest<int>
    {
        public string Name { get; set; }
    }
}
