using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Repositories.Context.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime? UpdateDatetime { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string JobTitle { get; set; }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<NumberRange> NumberRanges { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductProperty> ProductProperties { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<PurchaseProduct> PurchaseProducts { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderProduct> OrderProducts { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }
        public virtual DbSet<WarehouseAdjustment> WarehouseAdjustments { get; set; }
        public virtual DbSet<WarehouseInitialization> WarehouseInitializations { get; set; }
        public virtual DbSet<WarehousePrductRecord> WarehousePrductRecords { get; set; }
        public virtual DbSet<WarehouseProduct> WarehouseProduct { get; set; }
        public virtual DbSet<WarehouseTransfer> WarehouseTransfers { get; set; }
        public virtual DbSet<WarehouseTransferDetail> WarehouseTransferDetails { get; set; }
        public virtual DbSet<Company> Company { get; set; }

    }
   
}
