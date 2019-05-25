using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using ZxVentures.BackendChallenge.Infrastructure.Data;

namespace ZXVenture.BackendChallenge.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddMvc();

            services.AddMvc().AddJsonOptions(option =>
                {
                    option.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Unspecified;
                    option.SerializerSettings.Converters.Add(new GeoJsonSerializerConverter());

                }
            );

            services.AddRepositories();

            services.AddServices();

            services.AddDatabaseContext();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            new DatabaseContext().Configure();

            app.UseCors(builder => builder
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials());

            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature != null)
                    {
                        context.Response.Headers.Add("Content-Type", "text/plain");
                        context.Response.Headers.Add("Access-Control-Allow-Origin", context.Request.Headers["Origin"]);
                        await context.Response.WriteAsync(contextFeature.Error.Message);
                    }
                });
            });

            app.UseMvc();

        }
    }
}
