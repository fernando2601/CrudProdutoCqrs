using crudcqrs.application.features.commands;
using CrudCqrs.Application.Features.CommandHandler;
using CrudCqrs.Application.Features.Commands;
using CrudCqrs.Infrastructure.Context;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using static CrudCqrs.Application.Features.Commands.CreateProductCommand;

namespace CrudCqrs
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));

            services.AddTransient<ApplicationContext>();

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<IRequestHandler<CreateProductCommand,bool>, CreateProductCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteProductByIdCommand, int>, DeleteProductByIdCommandHandler>();
            services.AddTransient<IRequestHandler<Updateproductcommand, int>, UpdateProductCommandHandler>();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "CQRS.WebApi",
                });
            });

        }



        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CQRS.WebApi");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            });
        }
    }
}
