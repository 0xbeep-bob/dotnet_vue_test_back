using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_vue_test_back.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using dotnet_vue_test_back.Entities.Logic;
using dotnet_vue_test_back.Entities;

namespace dotnet_vue_test_back
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder => builder
                    .AllowAnyOrigin().SetIsOriginAllowed(x => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders("Content-Disposition")
                    .Build());
            });

            services.AddHttpContextAccessor();

            services.AddDbContext<DB>();
            services.AddScoped<UsersLogic>();

            services.AddMvc(options =>
            {
                options.Filters.Add<ExceptionHandler>();
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors();

            app.UseDefaultFiles(new DefaultFilesOptions
            {
                DefaultFileNames = new List<string> { "index.html" }
            });
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
