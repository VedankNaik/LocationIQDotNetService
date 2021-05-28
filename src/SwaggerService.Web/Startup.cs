using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SwaggerService.Core.Interfaces.Infrastructure.Repositories.V1;
using SwaggerService.Infrastructure.Repositories.V1;
using Microsoft.EntityFrameworkCore;
using SwaggerService.Core.Interfaces.Services.Service;
using SwaggerService.Core.Services.Service;
using SwaggerService.Core.Interfaces.Services.V1.Property;
using SwaggerService.Core.Services.V1.Property;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using SwaggerService.Core.Interfaces.Services.V2.Location;
using SwaggerService.Core.Services.V2.Location;
using SwaggerService.Core.Interfaces.Infrastructure.Repositories.V2;

namespace SwaggerService.Web
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
            // services.AddControllers();
            services.AddMvc();
            services.AddAutoMapper(typeof(Startup));
          
            // services.AddDbContext<ServiceRepository>(db => db.UseSqlServer(Configuration.GetConnectionString("mydb")));
            services.AddScoped<IServiceHelper,ServiceHelper>();
            services.AddScoped<IServiceRepository,ServiceRepository>();

            services.AddScoped<IPropertyHelper,PropertyHelper>();
            services.AddScoped<IPropertyRepository,PropertyRepository>();
            
            services.AddScoped<ILocationHelper,LocationHelper>();
            services.AddScoped<ILocationRepository,LocationRepository>();

            services.AddApiVersioning(v =>{
                v.AssumeDefaultVersionWhenUnspecified = true;
                v.DefaultApiVersion = new ApiVersion(1,0);
            });
            
            services.AddSwaggerGen(options => {
                options.SwaggerDoc("V1", new OpenApiInfo
                {
                    Version = "V1",
                    Title = "Database API",
                    Description = "Fetch database information",  
                });

               options.SwaggerDoc("V2", new OpenApiInfo
                {
                    Version = "V2",
                    Title = "Location API",
                    Description = "Call LocationIQ",  
                }); 

                options.SwaggerDoc("V3", new OpenApiInfo
                {
                    Version = "V3",
                    Title = "Service API",
                    Description = "Servvices",  
                });
                
                options.ResolveConflictingActions(a => a.First());
                options.OperationFilter<RemoveVersionParameter>();
                options.DocumentFilter<ReplaceVersionPath>();

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);

            });
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/V1/swagger.json", "Api V1");
                options.SwaggerEndpoint("/swagger/V2/swagger.json", "Api V2");
                options.SwaggerEndpoint("/swagger/V3/swagger.json", "Api V3");
                options.RoutePrefix = string.Empty;
            });

        }
    }
}