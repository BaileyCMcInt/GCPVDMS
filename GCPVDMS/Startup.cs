using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GCPVDMS.Data;
using GCPVDMS.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

//Testing
namespace GCPVDMS
{
    public class Startup
    {
        IConfigurationRoot Configuration;
        public Startup(IWebHostEnvironment env)
        {
           
            Configuration = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json").Build();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //var x = Configuration.GetConnectionString("GCPVDMSContextConnection");
            services.AddDbContext<GCPVDMSContext>(options => options.UseSqlServer(Configuration.GetConnectionString("GCPVDMSContextConnection")));
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("GCPVDMSContextConnection")));

            services.AddTransient<IEventRepository, EFEventRepository>();
            services.AddTransient<IGCPTaskRepository, EFGCPTaskRepository>();
            services.AddTransient<IVolunteerHourRepository, EFVolunteerHourRepository>();
            //services.AddTransient<IDriveRepository, EFDriveRepository>(); //added missing package that enables these to interact with connection string

            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<GCPVDMSContext>()
                    .AddDefaultUI()
                    .AddDefaultTokenProviders();
            services.AddControllersWithViews();
            services.AddRazorPages();
          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
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


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });

       
        }
    }
}
