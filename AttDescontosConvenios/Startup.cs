using AttDescontosConvenios.Repositories;
using AttDescontosConvenios.Repositories.Interfaces;
using AttDescontosConvenios.Services;
using AttDescontosConvenios.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using Pmenos.Core.Data.Connection.Factories;
using Pmenos.Core.Data.Connection.Factories.Interfaces;

namespace AttDescontosConvenios
{
    public class Startup
    {
        private static readonly string DATABASE_HOST = Environment.GetEnvironmentVariable("DATABASE_HOST");
        private static readonly string DATABASE_USER = Environment.GetEnvironmentVariable("DATABASE_USER");
        private static readonly string DATABASE_PASS = Environment.GetEnvironmentVariable("DATABASE_PASS");
        private static readonly string DATABASE_NAME = Environment.GetEnvironmentVariable("DATABASE_NAME");

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IConvenioService, ConvenioService>();
            services.AddScoped<IDescontoService, DescontoService>();
            services.AddScoped<IConvenioRepository, ConvenioRepository>();
            services.AddScoped<IDescontoRepository, DescontoRepository>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AttDescontosConvenios", Version = "v1" });
            });
            services
                .AddScoped<IDbConnectionFactory>(c => new SqlConnectionFactory("AttDescontosConvenios", DATABASE_HOST, DATABASE_NAME, DATABASE_USER, DATABASE_PASS, 120000));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AttDescontosConvenios v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
