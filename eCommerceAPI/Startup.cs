using eCommerceAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerceAPI.Services;
using eCommerceAPI.IServices;

using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Http;

namespace eCommerceAPI
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

            services.AddControllers();

            services.AddHttpClient();
            services.AddDbContext<eCommercedbContext>(options =>
            {
                options.UseSqlServer(Configuration["DbConnection"]);
            });

            services.AddTransient<ICustomerService, CustomerService>();

            services.AddSwaggerGen(swaggerOptions =>
            {
                swaggerOptions.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "ECommerce API",
                        Description = "API for eCommerce Application",
                        Version = "v1"
                    });
            });

            //services.AddMicrosoftIdentityWebApiAuthentication(Configuration, "AzureAd");
           // HttpClient.DefaultProxy = new WebProxy(new Uri("http://localhost:61762/"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "eCommerce API");
            });
            app.UseHttpsRedirection();
            app.UseRouting();
            //app.UseAuthentication();
            //app.Use(async (context, next) =>
            //{
            //    if (!context.User.Identity?.IsAuthenticated ?? false)
            //    {
            //        context.Response.StatusCode = 401;
            //        await context.Response.WriteAsync("Not Authenticated");
            //    }
            //    else await next();

            //});
            //app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });            
        }
    }
}
