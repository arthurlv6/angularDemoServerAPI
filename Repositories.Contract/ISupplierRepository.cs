using Repositories.Context.Entities;
using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Contract
{
    public interface ISupplierRepository
    {
        Task<IList<Supplier>> GetSupplierList(Condition c);
        Task<int> GetSupplierTotal(String name);
        Task<Supplier> GetSupplier(int id);
        Task Update(Supplier supplier);
        Task<Supplier> Insert(Supplier supplier);
        Task Delete(int id);
    }
}
