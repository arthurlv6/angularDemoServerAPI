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

namespace XUnitTest
{
    [Trait("Supplier","GetSingleSupplierUseCase Logic layer")]
    public class SupplierGetSingleUseCase
    {
        Mock<IMapper> Mapper;
        Mock<ISupplierRepository> SupplierRepository;
        UseCases.SupplierGetSingleUseCase SUT;
        public SupplierGetSingleUseCase()
        {
            Mapper = new Mock<IMapper>();
            SupplierRepository = new Mock<ISupplierRepository>();
            SUT = new UseCases.SupplierGetSingleUseCase(Mapper.Object, SupplierRepository.Object);
        }

        [Fact]
        public async Task ItThrowsValidation()
        {
            //arrange
            SupplierRepository.Setup(x => x.GetSupplier(It.IsAny<int>())).Returns(Task.FromResult(default(Supplier)));
            //act
            // assert
            await Assert.ThrowsAsync<ValidationExistException>(() => SUT.Handle(new UseCases.Requests.SupplierGetSingleRequest() { Id = It.IsAny<int>() }, new System.Threading.CancellationToken()));
        }
        [Fact]
        public async Task ItCheckReturnType()
        {
            //arrange
            SupplierRepository.Setup(x => x.GetSupplier(It.IsAny<int>())).Returns(Task.FromResult(new Supplier() { Id=1,Name="someone"}));

            Mapper.Setup(x => x.Map<SupplierModel>(It.IsAny<Supplier>())).Returns(new SupplierModel());
            //act
            var result=await SUT.Handle(new UseCases.Requests.SupplierGetSingleRequest(), new System.Threading.CancellationToken());
            // assert
            Assert.NotNull(result);
            Assert.IsType<SupplierModel>(result);
        }
    }
}
