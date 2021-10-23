using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NovoBanco.Dominio.Repositories;
using NovoBanco.Infraestrutura.Context;
using NovoBanco.Infraestrutura.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace NovoBanco.Api
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
                        
            services.AddDbContext<AppDbContext>(
                context => context.UseSqlServer(Configuration.GetConnectionString("Default"))
            );

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            RegistrarInjecaoRepositorios(services);
            RegistrarInjecaoServicos(services);

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            }).AddApiVersioning(options => {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });
            
            var apiProviderDescription = services.BuildServiceProvider().GetService<IApiVersionDescriptionProvider>();
            services.AddSwaggerGen(options =>
            {
                foreach (var description in apiProviderDescription.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(
                      description.GroupName,
                      new OpenApiInfo
                      {
                          Title = "NovoBanco.WebAPI",
                          Version = description.ApiVersion.ToString(),
                          Description = "Descrição da WebApi do Novo Banco",
                          Contact = new OpenApiContact
                          {
                              Name = "Guilherme Rodrigues",
                              Email = "guilhermejonathan@hotmail.com"
                          }
                      });
                }

                var xmlComentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlComentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlComentsFile);

                options.IncludeXmlComments(xmlComentsFullPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    }
                });
            }

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                dbContext.Database.Migrate();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void RegistrarInjecaoRepositorios(IServiceCollection services)
        {
            //services.AddScoped<IRepository, Repository>();
        }

        private void RegistrarInjecaoServicos(IServiceCollection services)
        {
           
        }
    }
}
