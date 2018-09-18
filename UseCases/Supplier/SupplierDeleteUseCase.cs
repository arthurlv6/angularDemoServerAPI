using MediatR;
using Repositories.Contract;
using Repositories.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Requests;

namespace UseCases
{
    public class SupplierDeleteUseCase : IRequestHandler<SupplierDeleteRequest, bool>
    {
        private readonly ISupplierRepository supplierRepository;

        public SupplierDeleteUseCase(ISupplierRepository supplierRepository)
        {
            this.supplierRepository = supplierRepository;
        }
        public async Task<bool> Handle(SupplierDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await supplierRepository.Delete(request.Id);
                return await Task.Run(() => true);
            }
            catch (ValidationExistException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new SaveException(ex.Message);
            }
            
        }
    }
}
