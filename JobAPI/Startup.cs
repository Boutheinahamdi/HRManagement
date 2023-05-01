using Azure.Storage.Blobs;
using JobAPI.Data;
using JobAPI.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobAPI
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
			services.AddCors(options =>
			{
				options.AddPolicy("bbb",
								  policy =>
								  {
									  policy.WithOrigins("*")
														  .AllowAnyHeader()
														  .AllowAnyMethod();
								  });
			});
			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "JobAPI", Version = "v1" });
			});
			services.AddScoped<JobContext>();
			services.AddScoped<ApplicantContext>();


			services.AddScoped<Igeneric, JobImplement>();
			services.AddScoped<IAppliquant, AppliquantImpl>();
            // Read the connection string from appsettings.json
            string connectionString = Configuration.GetConnectionString("MyStorageAccount");

            // Register the BlobServiceClient as a singleton
            services.AddSingleton(x => new BlobServiceClient(connectionString));
        }

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "JobAPI v1"));
			}
			app.UseCors("bbb");

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
