using MediatR;
using Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Requests;

namespace UseCases
{
    public class SupplierTotalUseCase : IRequestHandler<SupplierTotalRequest, int>
    {
        private readonly ISupplierRepository supplierRepository;

        public SupplierTotalUseCase(ISupplierRepository supplierRepository)
        {
            this.supplierRepository = supplierRepository;
        }
        public async Task<int> Handle(SupplierTotalRequest request, CancellationToken cancellationToken)
        {
            return await supplierRepository.GetSupplierTotal(request.Name);
        }
    }
}
