using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAPI.Entities;

namespace WebAPI.Models
{
    public class DataSeeder
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IHostingEnvironment _hosting;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DataSeeder(ApplicationDbContext ctx,
          IHostingEnvironment hosting,
          UserManager<ApplicationUser> userManager,
          RoleManager<IdentityRole> roleManager)
        {
            _ctx = ctx;
            _hosting = hosting;
            _userManager = userManager;
            _roleManager = roleManager;
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

            #region system users and roles
            var roleCheck =await _roleManager.RoleExistsAsync("Settings");
            if (!roleCheck)
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole("Settings"));
                
            }
            roleCheck = await _roleManager.RoleExistsAsync("23");
            if (!roleCheck)
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole("Products"));
            }
            roleCheck = await _roleManager.RoleExistsAsync("Inventories");
            if (!roleCheck)
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole("Inventories"));
            }
            roleCheck = await _roleManager.RoleExistsAsync("Suppliers");
            if (!roleCheck)
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole("Suppliers"));
            }

            roleCheck = await _roleManager.RoleExistsAsync("Purchases");
            if (!roleCheck)
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole("Purchases"));
            }
            roleCheck = await _roleManager.RoleExistsAsync("Customers");
            if (!roleCheck)
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole("Customers"));
            }
            roleCheck = await _roleManager.RoleExistsAsync("Sales");
            if (!roleCheck)
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole("Sales"));
            }
            roleCheck = await _roleManager.RoleExistsAsync("Reports");
            if (!roleCheck)
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole("Reports"));
            }
            roleCheck = await _roleManager.RoleExistsAsync("Website");
            if (!roleCheck)
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole("Website"));
            }



            var user = await _userManager.FindByEmailAsync("arthur.lv6@gmail.com");

            if (user == null)
            {
                user = new ApplicationUser()
                {
                    UserName = "arthur.lv6@gmail.com",
                    Email = "arthur.lv6@gmail.com",
                    Name = "Arthur",
                    JobTitle = "COO",
                    PhoneNumber = "0210578463"
                };

                var result = await _userManager.CreateAsync(user, "Tomhack!123");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Failed to create default user");
                }

                await _userManager.AddToRoleAsync(user, "Settings");
                await _userManager.AddToRoleAsync(user, "Products");
                await _userManager.AddToRoleAsync(user, "Inventories");
                await _userManager.AddToRoleAsync(user, "Suppliers");
                await _userManager.AddToRoleAsync(user, "Purchases");
                await _userManager.AddToRoleAsync(user, "Customers");
                await _userManager.AddToRoleAsync(user, "Sales");
                await _userManager.AddToRoleAsync(user, "Reports");
                await _userManager.AddToRoleAsync(user, "Website");

                await _userManager.AddClaimAsync(user, new Claim("Settings","true"));
                await _userManager.AddClaimAsync(user, new Claim("Products", "true"));
                await _userManager.AddClaimAsync(user, new Claim("Inventories", "true"));
                await _userManager.AddClaimAsync(user, new Claim("Suppliers", "true"));
                await _userManager.AddClaimAsync(user, new Claim("Purchases", "true"));
                await _userManager.AddClaimAsync(user, new Claim("Customers", "true"));
                await _userManager.AddClaimAsync(user, new Claim("Sales", "true"));
                await _userManager.AddClaimAsync(user, new Claim("Reports", "true"));
                await _userManager.AddClaimAsync(user, new Claim("Website", "true"));
            }
            user = await _userManager.FindByEmailAsync("selina@gmail.com");
            if (user == null)
            {
                user = new ApplicationUser()
                {
                    UserName = "selina@gmail.com",
                    Email = "selina@gmail.com",
                    Name="Selina",
                    JobTitle="CEO",
                    PhoneNumber="021099332"
                };

                var result = await _userManager.CreateAsync(user, "Tomhack!123");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Failed to create default user");
                }
                await _userManager.AddToRoleAsync(user, "Products");
                await _userManager.AddToRoleAsync(user, "Inventories");
                await _userManager.AddToRoleAsync(user, "Suppliers");
                await _userManager.AddToRoleAsync(user, "Purchases");
                await _userManager.AddToRoleAsync(user, "Customers");
                await _userManager.AddToRoleAsync(user, "Sales");

                await _userManager.AddClaimAsync(user, new Claim("Products", "true"));
                await _userManager.AddClaimAsync(user, new Claim("Inventories", "true"));
                await _userManager.AddClaimAsync(user, new Claim("Suppliers", "true"));
                await _userManager.AddClaimAsync(user, new Claim("Purchases", "true"));
                await _userManager.AddClaimAsync(user, new Claim("Customers", "true"));
                await _userManager.AddClaimAsync(user, new Claim("Sales", "true"));
            }
#endregion

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
            if (!_ctx.Customers.Any())
            {
                var items = GetJsonItems<Customer>("jsonData/customers.json");
                items.ToList().ForEach(s =>
                {
                    s.Id = 0;
                });
                _ctx.Customers.AddRange(items);
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
            if (!_ctx.Company.Any())
            {
                _ctx.Company.Add(new Company()
                {
                    Id = 0,
                    Name = "Company Name",
                    TradingName="Trading name",
                    Industry="Whole Sales",
                    OrganisationType="Company",
                    GST="",
                    Website="",
                    Timezone="",
                    Logo="",
                    Address="",
                    Suburb="",
                    City="",
                    State="",
                    Country="",
                    PostCode="",
                    FirstName="",
                    LastName="",
                    OfficePhone="",
                    MobileNumber="",
                    Email="",
                    Note="",
                    ValidDate=DateTime.Now,
                    Initialized=false
                });
                _ctx.SaveChanges();
            }
        }
    }
}
