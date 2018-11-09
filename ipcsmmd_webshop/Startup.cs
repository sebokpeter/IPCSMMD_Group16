using ipcsmmd_webshop.Core.ApplicationService;
using ipcsmmd_webshop.Core.ApplicationService.Impl;
using ipcsmmd_webshop.Core.DomainService;
using ipcsmmd_webshop.Infrastructure.Data;
using ipcsmmd_webshop.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using ipcsmmd_webshop.Helpers;
using System;

namespace ipcsmmd_webshop
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        private IHostingEnvironment _env { get; set; }

        public Startup(IHostingEnvironment env)
        {
            _env = env;
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{_env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            JwtSecurityKey.SetSecret("This is a secret");
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = JwtSecurityKey.Key,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(5)
                };
            });

            services.AddCors();

            if (_env.IsDevelopment())
            {
                services.AddDbContext<WebShopContext>(
                    opt => opt.UseSqlite("Data Source = WebShop.db"));


            }
            else if (_env.IsProduction())
            {
                services.AddDbContext<WebShopContext>(
                    opt => opt.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));
            }

            services.AddScoped<IBeerService, BeerService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IOrderService, OrderService>();
            // services.AddScoped<IOrderLineService, OrderLineService>();
            services.AddScoped<IBeerRepository, BeerRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            // services.AddScoped<IOrderLineReporitory, OrderLineRepository>();

            services.AddMvc().AddJsonOptions(opt =>
            {
                opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                using (IServiceScope scope = app.ApplicationServices.CreateScope())
                {
                    WebShopContext ctx = scope.ServiceProvider.GetService<WebShopContext>();
                    DBInitializer.SeedDB(ctx);
                }
                app.UseDeveloperExceptionPage();
            }
            else
            {
                using (IServiceScope scope = app.ApplicationServices.CreateScope())
                {
                    WebShopContext ctx = scope.ServiceProvider.GetService<WebShopContext>();
                    ctx.Database.EnsureCreated();
                    string password = "password123";
                    byte[] passwordSalt;
                    DBInitializer.CreatePasswordHash(password, out byte[] passwordHash, out passwordSalt);
                    ctx.Admins.Add(new Core.Entity.Admin
                    {
                        Username = "Admin",
                        PasswordHash = passwordHash,
                        PasswordSalt = passwordSalt
                    });
                }

                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            //app.UseCors(builder => builder.WithOrigins("https://ipcsmmd-webshop-group16.azurewebsites.net").AllowAnyMethod().AllowAnyHeader());
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseMvc();
        }
    }
}