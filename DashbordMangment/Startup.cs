using DashbordMangment.Models;
using DashbordMangment.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashbordMangment
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
			services.AddHttpClient("ProjectAPI", client => {

                //client.BaseAddress = new Uri("http://localhost:6001/");
				client.BaseAddress = new Uri(Configuration["ProjectAPI"]);
			});
			services.AddHttpClient("EmployeAPI", client => {

				//client.BaseAddress = new Uri("http://localhost:5001/");
				client.BaseAddress = new Uri(Configuration["EmployeAPI"]);
			});
			services.AddHttpClient("JobAPI", client => {

				//client.BaseAddress = new Uri("http://localhost:5002/");
				client.BaseAddress = new Uri(Configuration["JobAPI"]);
			});
			
			var mongoDbSettings = Configuration.GetSection(nameof(MongoDbConfig)).Get<MongoDbConfig>();
			services.AddIdentity<ApplicationUser, ApplicationRole>()
	   .AddMongoDbStores<ApplicationUser, ApplicationRole, Guid>
	   (
		   mongoDbSettings.ConnectionString, mongoDbSettings.Name
	   );
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
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
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
