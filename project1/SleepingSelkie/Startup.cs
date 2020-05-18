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
using Microsoft.Extensions.Options;
using SleepingSelkieDataAccess;
using SleepingSelkieBusinessLogic.IRepositories;
using SleepingSelkieDataAccess.Repositories;
using SleepingSelkieBusinessLogic;

namespace SleepingSelkie
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
         //This next block adds the session services needed to use sesssions for login
            //services.AddMvc();
            services.AddDistributedMemoryCache();
            services.AddSession();
            /// Adds Database context with options to the services. 
            services.AddDbContext<SelkieContext>(options =>
          options.UseSqlServer(Configuration.GetConnectionString("TheSleepingSelkie.db")));
          services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddSingleton<Singleton>();
            services.AddScoped<Scoped>();
            services.AddTransient<Transient>();
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
            app.UseSession();
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
    }
}
