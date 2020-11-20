using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Management.Data;
using Management.Interfaces;
using Management.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
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
            services.AddSingleton<IAccountsService, AccountsService>();
            services.AddSingleton<ISysLogsService, SysLogsService>();
            services.AddSingleton<IStockService, StockService>();
            services.AddHttpClient<IAccountsService, AccountsService>("Accounts Service");
            services.AddHttpClient<ISysLogsService, SysLogsService>("System Logs Service");
            services.AddHttpClient<IStockService, StockService>("Stock Service");
        }
    }
}
