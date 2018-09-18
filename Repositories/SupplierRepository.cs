using Microsoft.EntityFrameworkCore;
using Repositories.Context.Entities;
using Repositories.Contract;
using Repositories.Entities;
using Repositories.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repositories
{
    public class SupplierRepository : BaseEFRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<IList<Supplier>> GetSupplierList(Condition c)
        {
            Expression<Func<Supplier, bool>> predicate;
            if (string.IsNullOrEmpty(c.Name))
            {
                predicate = d => true;
            }
            else
            {
                predicate = d => d.Name.Contains(c.Name);
            }
            var query = GetQuery(predicate).Where(d => d.Deleted == false);
            switch (c.Sort)
            {
                case "name":
                    query = query.OrderBy(x => x.Name);
                    break;
                case "nameDesc":
                    query = query.OrderByDescending(x => x.Name);
                    break;
                case "dateDesc":
                    query = query.OrderByDescending(x => x.ModifiedDate);
                    break;
                case "date":
                    query = query.OrderBy(x => x.ModifiedDate);
                    break;
                case "email":
                    query = query.OrderBy(x => x.ContactEmail);
                    break;
                case "emailDesc":
                    query = query.OrderByDescending(x => x.ContactEmail);
                    break;
                default:
                    break;
            }
            return await query
                .Skip(c.PageSize * (c.PageNumber - 1))
                .Take(c.PageSize)
                .Include(d => d.Products)
                .ToListAsync();
        }

        public async Task<int> GetSupplierTotal(string name)
        {
            Expression<Func<Supplier, bool>> predicate;
            if (string.IsNullOrEmpty(name))
            {
                predicate = d => true;
            }
            else
            {
                predicate = d => d.Name.Contains(name);
            }
            return await GetQuery(predicate).Where(d => d.Deleted == false).CountAsync();
        }

        async Task ISupplierRepository.Delete(int id)
        {
            var supplier = GetQuery(d => d.Id == id).FirstOrDefault();
            if (supplier is null) throw new ValidationExistException(ExceptionMessage.ValidationIdExceptionMessage.ToString());
            Remove(supplier);
            await SaveChangesAsync();
        }

        async Task<Supplier> ISupplierRepository.GetSupplier(int id)
        {
            return await GetQuery(d => d.Id == id).FirstOrDefaultAsync();
        }

        async Task<Supplier> ISupplierRepository.Insert(Supplier supplier)
        {
            Add(supplier);
            await SaveChangesAsync();
            return supplier;
        }

        async Task ISupplierRepository.Update(Supplier supplier)
        {
            Update(supplier);
            await SaveChangesAsync();
        }
    }
}
