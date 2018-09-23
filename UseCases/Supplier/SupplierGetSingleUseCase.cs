using AutoMapper;
using MediatR;
using Models;
using Repositories;
using Repositories.Contract;
using Repositories.Entities.Exceptions;
using Repositories.Extensions;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Requests;

namespace UseCases
{
    public class SupplierGetSingleUseCase : IRequestHandler<SupplierGetSingleRequest, SupplierModel>
    {
        internal readonly IMapper mapper;
        internal readonly ISupplierRepository supplierRepository;

        public SupplierGetSingleUseCase(IMapper mapper, ISupplierRepository supplierRepository)
        {
            this.mapper = mapper;
            this.supplierRepository = supplierRepository;
        }

        public async Task<SupplierModel> Handle(SupplierGetSingleRequest request, CancellationToken cancellationToken)
        {
            var supplier = await supplierRepository.GetSupplier(request.Id);

            if (supplier is null)
            {
                throw new ValidationExistException(ExceptionMessage.ValidationIdExceptionMessage.ToDescription());
            }

            return mapper.Map<SupplierModel>(supplier);
        }
    }
}
