using ciclojobs.BL.Contracts;
using ciclojobs.BL.Implementations;
using ciclojobs.DAL.Entities;
using ciclojobs.DAL.Repositories.Contracts;
using ciclojobs.DAL.Repositories.Implementations;
using ciclosjobs.Core.AutoMapperProfiles;
using ciclosjobs.Core.Security;
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
using System.Threading.Tasks;

namespace ciclosjobs.API
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
            //Para habilitar CORS en nuestra API
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            AddSwagger(services);

            services.AddAutoMapper(cfg => cfg.AddProfile(new AutoMapperProfile()));

            services.AddDbContext<ciclojobsContext>(opts => opts.UseMySql(Configuration["ConnectionString:ciclojobsDB"],
                ServerVersion.AutoDetect(Configuration["ConnectionString:ciclojobsDB"])));

            //Aquí las inyecciones: Interfaz - Clase
            services.AddScoped<IAlumnosRepository, AlumnosRepository>();
            services.AddScoped<IEmpresaRepository,EmpresaRepository>();
            services.AddScoped<IOfertasRepository, OfertaRepository>();
            services.AddScoped<IAlumnoBL, AlumnoBL>();
            services.AddScoped<IEmpresaBL, EmpresaBL>();
            services.AddScoped<IOfertaBL, OfertaBL>();
            services.AddScoped<IPasswordGenerator, PasswordGenerator>();

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
    
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Foo API V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"Foo {groupName}",
                    Version = groupName,
                    Description = "Foo API",
                    Contact = new OpenApiContact
                    {
                        Name = "Foo Company",
                        Email = string.Empty,
                        Url = new Uri("https://foo.com/"),
                    }
                });
            });
        }

    }
}
