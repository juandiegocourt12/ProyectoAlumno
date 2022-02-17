using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Net52.Rest.API.Construction.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5.PresentacionMVC
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
            string ProyAlumnoConnection = Configuration.GetConnectionString("ProyAlumnoConnection");
            services.AddDbContext<ProyalumnoContext>(opt => opt.UseSqlServer(ProyAlumnoConnection));
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
                    name: "Route1",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "Route2",
                    pattern: "{controller=Home}/{action=Edit}/{id?}");

                endpoints.MapControllerRoute(
                    name: "Route3",
                    pattern: "{controller=Home}/{action=Details}/{id?}");

                endpoints.MapControllerRoute(
                    name: "Route4",
                    pattern: "{controller=Home}/{action=Create}/{id?}");

                endpoints.MapControllerRoute(
                    name: "Route5",
                    pattern: "{controller=Home}/{action=Delete}/{id?}");


            });
        }
    }
}
