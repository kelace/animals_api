using Animals.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
using System.Threading.Tasks;
using Animals.Infrastructure.Extentions;
using MediatR;
using Animals.Application.Features.Book.Commands;
using Animals.Application.Mappers;
using Animals.Api.Extentions;
using AutoMapper;
using Animals.Api.Mappers;

namespace Animals.Api
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
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(
               Configuration.GetConnectionString("DefaultConnection"),
               x => x.MigrationsAssembly("Animals.Infrastructure")), ServiceLifetime.Transient);
            services.AddAppServiceConfigure();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DogProfile());
                mc.AddProfile(new RequestProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddControllers();
            services.AddMediatR(typeof(CreateDogCommand).Assembly);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Animals.Api", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Animals.Api v1"));
            }

            app.UseRouting();
            app.UseRequestLimit(5000, 2);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                 name: "default",
                 pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
