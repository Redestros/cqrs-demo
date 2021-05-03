using Autofac;
using cqrs_demo.CQRS;
using cqrs_demo.Handlers;
using cqrs_demo.Services.Customers;
using cqrs_demo.Validations;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rammus.Services.Customers;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace cqrs_demo
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
            services.RegisterDemoServices();
            services.RegisterCommandHandlers();
            services.RegisterQueriesHandlers();
            services.RegisterProcessors();
            // Initialise AutoMapper
            services.AddAutoMapper(typeof(Startup));

            services.AddSwaggerGen();

            services.AddControllers()
                .AddFluentValidation(fv => { });

            services.AddValidators();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rammus API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        //public void ConfigureContainer(ContainerBuilder builder)
        //{
        //    builder.RegisterType<CommandProcessor>().As<ICommandProcessor>();
        //    builder.RegisterType<QueryProcessor>().As<IQueryProcessor>();
        //}
    }
}
