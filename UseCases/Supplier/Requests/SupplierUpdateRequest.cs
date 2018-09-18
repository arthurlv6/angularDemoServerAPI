using MediatR;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace UseCases.Requests
{
    public class SupplierUpdateRequest : IRequest<bool>
    {
        public SupplierModel SupplierModel { get; set; }
    }
}
