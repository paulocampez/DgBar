using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DgBar.Infra.Data.Context;
using DgBar.Services.Api.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MediatR;
using AutoMapper;
using DgBar.Infra.CrossCutting.IoC;

namespace DgBar.Services.Api
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
            services.AddDbContext<DgBarContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddAutoMapperSetup();
            services.AddMediatR(typeof(Startup));
            services.AddAutoMapper(typeof(Startup));


            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            //  #region "CORS"
            //  // include support for CORS
            //  //More often than not, we will want to specify that our API accepts requests coming from other origins (other domains).When issuing AJAX requests, browsers make preflights to check if a server accepts requests from the domain hosting the web app. If the response for these preflights don't contain at least the Access-Control-Allow-Origin header specifying that accepts requests from the original domain, browsers won't proceed with the real requests(to improve security).
            //  services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsPolicy-public",
            //        builder => builder.AllowAnyOrigin()   //WithOrigins and define a specific origin to be allowed (e.g. https://mydomain.com)
            //            .AllowAnyMethod()
            //            .AllowAnyHeader()
            //    //.AllowCredentials()
            //    .Build());
            //});
            //  #endregion

            RegistrarServicos(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("MyPolicy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dg Bar");
            });
        }
        private static void RegistrarServicos(IServiceCollection services)
        {
            // dependencias de outras camadas
            Bootstrapper.RegisterServices(services);
        }
    }
}
