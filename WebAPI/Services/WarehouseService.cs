using Repositories.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services
{

    public interface IWarehouseService
    {
        List<IOperation> Operations();
    }
    public class WarehouseService : IWarehouseService
    {
        public List<IOperation> Operations()
        {
            var list = new List<IOperation>();
            list.Add(new WarehouseUpdateName());
            list.Add(new WarehouseUpdateStatus());
            list.Add(new WarehouseUpdateDescription());
            return list;
        }
    }
    public class WarehouseUpdateName : IOperation
    {

        public bool IsMatch(string type)
        {
            return type.ToLower() == "name";
        }

        public async Task UpdateUser(IdAndValue user, ApplicationDbContext context)
        {
            try
            {
                var existing = context.Warehouses.FirstOrDefault(d => d.Id == user.Id);
                existing.Name = user.Value;
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }

        }
    }
    public class WarehouseUpdateStatus : IOperation
    {
        public bool IsMatch(string type)
        {
            return type.ToLower() == "status";
        }
        public async Task UpdateUser(IdAndValue user, ApplicationDbContext context)
        {
            try
            {
                var existing = context.Warehouses.FirstOrDefault(d=>d.Id==user.Id);
                existing.Status = user.Value;
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }
        }
    }
    public class WarehouseUpdateDescription : IOperation
    {
        public bool IsMatch(string type)
        {
            return type.ToLower() == "description";
        }
        public async Task UpdateUser(IdAndValue user, ApplicationDbContext context)
        {
            try
            {
                var existing = context.Warehouses.FirstOrDefault(d => d.Id == user.Id);
                existing.Description = user.Value;
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }
        }
    }

    public interface IOperation
    {
        Boolean IsMatch(string user);
        Task UpdateUser(IdAndValue user, ApplicationDbContext context);
    }
    public class IdAndValue
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }
}
