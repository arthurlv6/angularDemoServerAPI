using MediatR;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace UseCases.Requests
{
    public class SupplierDeleteRequest : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
