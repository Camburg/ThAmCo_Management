using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Management.Data;
using Management.Interfaces;
using Management.Services;
using Management.Services.Fake;
using Management.Services.Real;

namespace Management
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ManagementDbContext>(options =>
            {
                options.UseMySql(Configuration.GetConnectionString("ManagementDbConnectionString"));
            });
            services.AddSwaggerGen();

            if (Environment.IsDevelopment())
            {
                AddMockServices(services);
            }
            else 
            {
                AddRealServices(services);
            }

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/SysLogs/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", "ThAmCo Management API"));

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=SysLogs}/{action=Index}/{id?}");
            });
        }

        private void AddMockServices(IServiceCollection services)
        {
            services.AddSingleton<IAccountsService, FakeAccountsService>();
            services.AddSingleton<ISysLogsService, FakeSysLogsService>();
            services.AddSingleton<IStockService, FakeStockService>();
        }

        private void AddRealServices(IServiceCollection services)
        {
            services.AddHttpClient<IAccountsService, AccountsService>("Accounts Service", x => x.BaseAddress = new Uri("https://thamco-accounts.azurewebsites.net/api/Account/"));
            services.AddHttpClient<ISysLogsService, SysLogsService>("System Logs Service", x => x.BaseAddress = new Uri("https://thamco-syslogs.azurewebsites.net/api/SysLogs/"));
            //services.AddHttpClient<IStockService, StockService>("Stock Service", x => x.BaseAddress = new Uri("https://thamco-stock-management.azurewebsites.net/"));
            services.AddScoped<IStockService, FakeStockService>();
        }
    }
}
