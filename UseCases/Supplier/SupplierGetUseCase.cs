using System;
using UseCases.Requests;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Repositories.Contract;
using AutoMapper;
using System.Collections.Generic;
using Models;
using System.Linq;

namespace UseCases
{
    public class SupplierGetUseCase : IRequestHandler<SupplierGetRequest, IList<SupplierModel>>
    {
        private readonly ISupplierRepository supplierRepository;
        private readonly IMapper mapper;

        public SupplierGetUseCase(IMapper mapper, ISupplierRepository supplierRepository)
        {
            this.supplierRepository = supplierRepository;
            this.mapper = mapper;
        }

        public async Task<IList<SupplierModel>> Handle(SupplierGetRequest request, CancellationToken cancellationToken)
        {
            var list = await supplierRepository.GetSupplierList
                (
                new Condition() { Name = request.Name, Sort = request.Sort, PageNumber = request.PageNumber, PageSize = request.PageSize }
                );

            return mapper.Map<IList<SupplierModel>>(list);
        }
    }
}
