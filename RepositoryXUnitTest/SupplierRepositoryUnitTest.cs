using Moq;
using Repositories;
using Repositories.Entities;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;
using Repositories.Contract;
using System.Threading.Tasks;

namespace RepositoryXUnitTest
{
    [Trait("Repository","Supplier")]
    public class SupplierRepositoryUnitTest
    {
        Mock<ISupplierRepository> SUT;

        IList<Supplier> Suppliers;
        public SupplierRepositoryUnitTest()
        {

            SUT = new Mock<ISupplierRepository>();
            Suppliers = new List<Supplier>
                {
                    new Supplier { Id = 1, Name = "arthur lyu",
                        PhysicalStreetAddress = "Short description here" },
                    new Supplier { Id = 2, Name = "Tom Cool",
                        PhysicalStreetAddress = "10 Cook St" },
                    new Supplier { Id = 3, Name = "John Trov",
                        PhysicalStreetAddress = "Short description here" },
                    new Supplier { Id = 1, Name = "Anni Scott",
                        PhysicalStreetAddress = "Short description here" },
                };

            // Allows us to test saving a supplier
            /*
            mockProductRepository.Setup(mr => mr.Save(It.IsAny<Product>())).Returns(
                (Product target) =>
                {
                    DateTime now = DateTime.Now;

                    if (target.ProductId.Equals(default(int)))
                    {
                        target.DateCreated = now;
                        target.DateModified = now;
                        target.ProductId = products.Count() + 1;
                        products.Add(target);
                    }
                    else
                    {
                        var original = products.Where(
                            q => q.ProductId == target.ProductId).Single();

                        if (original == null)
                        {
                            return false;
                        }

                        original.Name = target.Name;
                        original.Price = target.Price;
                        original.Description = target.Description;
                        original.DateModified = now;
                    }

                    return true;
                });

            // Complete the setup of our Mock Product Repository
            this.MockProductsRepository = mockProductRepository.Object;
            */
        }
        [Fact]
        public async Task GetSupplierListAsync()
        {
            SUT.Setup(x => x.GetSupplierList(It.IsAny<Condition>()))
               .Returns(Task.FromResult(Suppliers));
            var condition = new Condition();
            var list=await SUT.Object.GetSupplierList(condition);
            SUT.Verify(x => x.GetSupplierList(condition), Times.Once());
            Assert.Equal(4, list.Count());
        }

    }
}
