using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;

namespace WebAPI.Models
{
    public class DataSeeder
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IHostingEnvironment _hosting;
        private readonly UserManager<ApplicationUser> _userManager;

        public DataSeeder(ApplicationDbContext ctx,
          IHostingEnvironment hosting,
          UserManager<ApplicationUser> userManager)
        {
            _ctx = ctx;
            _hosting = hosting;
            _userManager = userManager;
        }
        private IEnumerable<T> GetJsonItems<T>(string jsaonPath)
        {
            var filepath = Path.Combine(_hosting.ContentRootPath, jsaonPath);
            var json = File.ReadAllText(filepath);
            return JsonConvert.DeserializeObject<IEnumerable<T>>(json);
        }
        public async Task Seed()
        {
            _ctx.Database.EnsureCreated();

            var user = await _userManager.FindByEmailAsync("arthur.lv6@gmail.com");

            if (user == null)
            {
                user = new ApplicationUser()
                {
                    UserName = "arthur.lv6@gmail.com",
                    Email = "arthur.lv6@gmail.com"
                };

                var result = await _userManager.CreateAsync(user, "Tomhack!123");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Failed to create default user");
                }
            }
            
            if (!_ctx.Suppliers.Any())
            {
                var items = GetJsonItems<Supplier>("jsonData/suppliers.json");
                items.ToList().ForEach(s => {
                    s.Id = 0;
                    });
                _ctx.Suppliers.AddRange(items);
                _ctx.SaveChanges();
            }
            if (!_ctx.ProductCategories.Any())
            {
                var items = GetJsonItems<ProductCategory>("jsonData/categories.json");
                items.ToList().ForEach(s => s.Id = 0);
                _ctx.ProductCategories.AddRange(items);
                _ctx.SaveChanges();
            }
            if (!_ctx.Products.Any())
            {
                var items = GetJsonItems<Product>("jsonData/products.json");
                items.ToList().ForEach(s => 
                {
                    s.Id = 0;
                    if (s.ProductCategoryId == null)
                        s.ProductCategoryId = _ctx.ProductCategories.FirstOrDefault()?.Id;
                    if (s.SupplierId == null)
                        s.SupplierId = _ctx.Suppliers.FirstOrDefault()?.Id;
                    if (String.IsNullOrEmpty( s.Profile))
                        s.Profile = "http://www.virukivi.ee/wp-content/themes/virukivi/images/none.jpg";
                    //s.ProductImages.ToList().ForEach(i => { i.Id = 0;i.ProductId = 0; });
                    //s.ProductProperties.ToList().ForEach(p => { p.Id = 0;p.ProductId = 0; });
                    //s.ProductCategory.Id = 0;
                });
                _ctx.Products.AddRange(items);
                _ctx.SaveChanges();
            }
            if (!_ctx.ProductImages.Any())
            {
                var items = GetJsonItems<ProductImage>("jsonData/productImages.json");
                
                items.ToList().ForEach(s =>
                {
                    s.Id = 0;
                    if (s.ProductId == 0)
                        s.ProductId = _ctx.Products.FirstOrDefault()?.Id;
                });
                _ctx.ProductImages.AddRange(items);
                _ctx.SaveChanges();
            }
            if (!_ctx.ProductProperties.Any())
            {
                var items = GetJsonItems<ProductProperty>("jsonData/productProperties.json");

                items.ToList().ForEach(s =>
                {
                    s.Id = 0;
                    if (s.ProductId == 0)
                        s.ProductId = _ctx.Products.FirstOrDefault().Id;
                });
                _ctx.ProductProperties.AddRange(items);
                _ctx.SaveChanges();
            }
            if (!_ctx.Warehouses.Any())
            {
                _ctx.Warehouses.Add(new Warehouse() { Id=0, Name="Main" });
                _ctx.Warehouses.Add(new Warehouse() { Id = 0, Name = "East" });
                _ctx.Warehouses.Add(new Warehouse() { Id = 0, Name = "West" });
                _ctx.Warehouses.Add(new Warehouse() { Id = 0, Name = "South" });
                _ctx.Warehouses.Add(new Warehouse() { Id = 0, Name = "North" });
                _ctx.SaveChanges();
            }
        }
    }
}
