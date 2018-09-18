using AutoMapper;
using MediatR;
using Models;
using Repositories;
using Repositories.Contract;
using Repositories.Entities.Exceptions;
using Repositories.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Requests;

namespace UseCases
{
    class SupplierUpdateUseCase : IRequestHandler<SupplierUpdateRequest,bool>
    {
        private readonly IMapper mapper;
        private readonly ISupplierRepository supplierRepository;

        public SupplierUpdateUseCase(IMapper mapper, ISupplierRepository supplierRepository)
        {
            this.mapper = mapper;
            this.supplierRepository = supplierRepository;
        }
        public async Task<bool> Handle(SupplierUpdateRequest request, CancellationToken cancellationToken)
        {
            var supplier = await supplierRepository.GetSupplier(request.SupplierModel.Id);

            if (supplier is null)
            {
                throw new ValidationExistException(ExceptionMessage.ValidationIdExceptionMessage.ToDescription());
            }

            try
            {
                mapper.Map(request.SupplierModel, supplier);

                supplier.ModifiedDate = DateTime.UtcNow;

                await supplierRepository.Update(supplier);

                return await Task.Run(() => true);
            }
            catch (Exception ex)
            {
                throw new SaveException(ExceptionMessage.SaveExceptionMessage.ToDescription());
            }
           
        }
    }
}
