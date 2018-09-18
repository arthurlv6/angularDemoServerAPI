using AutoMapper;
using MediatR;
using Models;
using Repositories;
using Repositories.Contract;
using Repositories.Entities;
using Repositories.Entities.Exceptions;
using Repositories.Extensions;
using System;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Requests;

namespace UseCases
{
    class SupplierInsertUseCase : IRequestHandler<SupplierInsertRequest, SupplierModel>
    {
        private readonly IMapper mapper;
        private readonly ISupplierRepository supplierRepository;

        public SupplierInsertUseCase(IMapper mapper, ISupplierRepository supplierRepository)
        {
            this.mapper = mapper;
            this.supplierRepository = supplierRepository;
        }
        public async Task<SupplierModel> Handle(SupplierInsertRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var supplier = new Supplier();
                mapper.Map(request.SupplierModel, supplier);
                supplier.CreatedDate = DateTime.UtcNow;
                await supplierRepository.Insert(supplier);
                return mapper.Map<SupplierModel>(supplier);
            }
            catch (Exception)
            {
                throw new SaveException(ExceptionMessage.SaveExceptionMessage.ToDescription());
            }
            
        }
    }
}
