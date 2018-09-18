using MediatR;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace UseCases.Requests
{
    public class SupplierInsertRequest : IRequest<SupplierModel>
    {
        public SupplierModel SupplierModel { get; set; }
    }
}
