using AutoMapper;
using Moq;
using Repositories.Contract;
using System;
using Xunit;
using UseCases;
using Repositories.Entities.Exceptions;
using System.Threading.Tasks;
using Repositories.Entities;
using Models;
using System.Collections.Generic;
using UseCases.Requests;

namespace XUnitTest
{
    [Trait("Supplier","GetUseCase Logic layer")]
    public class SupplierGetUseCase
    {
        Mock<IMapper> Mapper;
        Mock<ISupplierRepository> SupplierRepository;
        IList<SupplierModel> SupplierModels;
        IList<Supplier> Suppliers;
        UseCases.SupplierGetUseCase SUT;
        public SupplierGetUseCase()
        {
            Mapper = new Mock<IMapper>();
            SupplierRepository = new Mock<ISupplierRepository>();

            SupplierModels = new List<SupplierModel>();
            SupplierModels.Add(new SupplierModel() { Id = 1, Name = "arthur" });

            Suppliers = new List<Supplier>();
            Suppliers.Add(new Supplier() { Id = 1, Name = "arthur" });

            SUT = new UseCases.SupplierGetUseCase(Mapper.Object, SupplierRepository.Object);
        }
        

        [Fact]
        public async Task ItCheckReturnType()
        {
            //arrange
            SupplierRepository.Setup(x => x.GetSupplierList(It.IsAny<Condition>())).Returns(Task.FromResult(Suppliers));

            Mapper.Setup(x => x.Map<IList<SupplierModel>>(It.IsAny<IList<Supplier>>())).Returns(SupplierModels);
            //act
            var result=await SUT.Handle(new SupplierGetRequest(), new System.Threading.CancellationToken());
            // assert
            Assert.IsAssignableFrom<IList<SupplierModel>>(result);
        }
    }
}
