using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace UserManager.API
{
    [ExcludeFromCodeCoverage]
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

            new IoC.DependencyInjection(services);

            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo 
                {
                    Version = "v1",
                    Title = "API User Manager",
                    Description = "API para controle de usuarios",
                    TermsOfService = new Uri("https://abcxyz.com"),
                    Contact = new OpenApiContact()
                    {
                        Name = "Rafael",
                        Email = "rafael@rafael.com",
                        Url = new Uri("https://rafael.com")
                    },
                    License = new OpenApiLicense()
                    {
                        Name = "Open Source",
                        Url = new Uri("https://opensource.com")
                    }
                });

                var arquivoSwaggerXML = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var diretorioArquivoXML = Path.Combine(AppContext.BaseDirectory, arquivoSwaggerXML);
                swagger.IncludeXmlComments(diretorioArquivoXML);
            });

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseSwagger();

            app.UseSwaggerUI(ui => 
            {
                ui.SwaggerEndpoint("./v1/swagger.json", "API User Manager V1");
            });

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
