using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Repositories.Context.Entities;
using UseCases;
using WebAPI.Filters;
using WebAPI.Models;
using WebAPI.Services;
using MediatR;
using Models;
using UseCases.Requests;
using Repositories;
using Repositories.Contract;
using WebAPI.Extensions;
using WebAPI.Models.Mappers;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();
            _env = env;
            _config = builder.Build();
        }
        private IHostingEnvironment _env;
        public IConfiguration Configuration { get; }
        private IConfigurationRoot _config;
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowConfigOrigin",
                    builder => builder.WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());

                options.AddPolicy("AllowAll",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .SetPreflightMaxAge(TimeSpan.FromSeconds(300)));
            });
            services.AddSingleton(_config);
            
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(_config.GetConnectionString("DatabaseString")), ServiceLifetime.Scoped);

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
                

            //impliment bearer token
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }
            ).AddJwtBearer(jwtBearerOptions =>
            {
                jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateActor = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = _config["Tokens:Issuer"],
                    ValidAudience = _config["Tokens:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("FooBarQuuxIsTheStandardTypeOfStringWeUse12345"))
                };
            });

            services.AddAuthorization(cfg =>
            {
                cfg.AddPolicy("SystemPolicy", p => {
                    p.RequireClaim("Settings", "true");
                    p.RequireClaim("Products", "true");
                });
                cfg.AddPolicy("Products", p => {
                    p.RequireClaim("Products", "True");
                });
            });

            services.AddTransient<DataSeeder>();

            services.AddTransient<ClaimsPrincipal>( s => s.GetService<IHttpContextAccessor>().HttpContext.User);

            services.AddAutoMapper(typeof(ModelProfile).GetTypeInfo().Assembly);

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IWarehouseService, WarehouseService>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();

            //mediatr
            services.AddMediatR(GetAssembliesToScan());

            // mvc
            services.AddMvc(opt =>
            {
                opt.Filters.Add(typeof(ValidateModelAttribute));
            }).AddJsonOptions(opt =>
            {
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

        }
        private static Assembly[] GetAssembliesToScan()
        {
            return new[]
            {
                typeof(Startup).GetTypeInfo().Assembly,
                typeof(SupplierGetRequest).GetTypeInfo().Assembly,
                typeof(SupplierGetUseCase).GetTypeInfo().Assembly,
                
            };
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //loggerFactory.AddConsole(_config.GetSection("Logging"));

            loggerFactory.AddDebug(LogLevel.Information);

            app.UseCors("AllowAll");

            app.UseAuthentication();
            app.UseExceptionHandler(appBuilder =>
            {
                appBuilder.Use(async (context, next) =>
                {
                    var error = context.Features[typeof(IExceptionHandlerFeature)] as IExceptionHandlerFeature;

                    //when authorization has failed, should retrun a json message to client
                    if (error != null && error.Error is SecurityTokenExpiredException)
                    {
                        context.Response.StatusCode = 401;
                        context.Response.ContentType = "application/json";

                        await context.Response.WriteAsync(JsonConvert.SerializeObject(new
                        {
                            State = "Unauthorized",
                            Msg = "token expired"
                        }));
                    }
                    //when orther error, retrun a error message json to client
                    else if (error != null && error.Error != null)
                    {
                        context.Response.StatusCode = 500;
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(new
                        {
                            State = "Internal Server Error",
                            Msg = error.Error.Message
                        }));
                    }
                    //when no error, do next.
                    else await next();
                });
            });
            app.UseMvc();

            if (env.IsDevelopment())
            {
                // Seed the database
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var seeder = scope.ServiceProvider.GetService<DataSeeder>();
                    seeder.Seed().Wait();
                }
                // logging
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseWebApiExceptionHandler();
            }
        }
    }
}
