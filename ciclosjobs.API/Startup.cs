using ciclojobs.BL.Contracts;
using ciclojobs.BL.Implementations;
using ciclojobs.DAL.Entities;
using ciclojobs.DAL.Repositories.Contracts;
using ciclojobs.DAL.Repositories.Implementations;
using ciclosjobs.Core.AutoMapperProfiles;
using ciclosjobs.Core.Security;
using ciclosjobs.Core.Security.EmailSender;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            string[] exponseHeaders = { "token" };
            //Para habilitar CORS en nuestra API
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSetOrigins", options =>
                {

                    options.AllowAnyOrigin();
                    options.AllowAnyMethod();
                    options.AllowAnyHeader();
                    options.WithExposedHeaders(exponseHeaders);

                });

            });
            AddSwagger(services);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SecretKey"]))
                };
            });
            services.AddAuthorization(config =>
            {
                var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);
                defaultAuthorizationPolicyBuilder = defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();
                config.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
               // config.AddPolicy(Policies.EMPRESA, policy => { policy.RequireClaim("Role", Policies.EMPRESA); });
            });



            services.AddAutoMapper(cfg => cfg.AddProfile(new AutoMapperProfile()));

            services.AddDbContext<ciclojobsContext>(opts => opts.UseMySql(Configuration["ConnectionString:ciclojobsDB"],
                ServerVersion.AutoDetect(Configuration["ConnectionString:ciclojobsDB"])));

            //Aquí las inyecciones: Interfaz - Clase
            services.AddScoped<IAlumnosRepository, AlumnosRepository>();
            services.AddScoped<IEmpresaRepository,EmpresaRepository>();
            services.AddScoped<IOfertasRepository, OfertaRepository>();
            services.AddScoped<IAlumnoBL, AlumnoBL>();
            services.AddScoped<IEmpresaBL, EmpresaBL>();
            services.AddScoped<ICicloRepository, CicloRepository>();
            services.AddScoped<IOfertaBL, OfertaBL>();
            services.AddScoped<IProvinciasRepository, ProvinciasRepository>();
            services.AddScoped<IProvinciasBL, ProvinciasBL>();
            services.AddScoped<ICicloBL, CicloBL>();
            services.AddScoped<ITipoCicloRepository, TipoCicloRepository>();
            services.AddScoped<ITipoCicloBL, TipoCicloBL>();
            services.AddScoped<IFamiliaProfeRepository, FamiliaProfeRepository>();
            services.AddScoped<IFamiliaProfeBL, FamiliaProfeBL>();
            services.AddScoped<IInscripcionesRepository, InscripcionesRepository>();
            services.AddScoped<IInscripcioneBL, InscripcionesBL>();
            services.AddScoped<IJwtBearer, JwtBearer>();
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IContractoBL, ContractoBL>();
            services.AddScoped<IContratoRepository, ContratoRepository>();
            services.AddScoped<IPasswordGenerator, PasswordGenerator>();

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
    
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Foo API V1");
            });
             
            app.UseRouting();

            app.UseCors("AllowSetOrigins");

            app.UseAuthorization();
            app.UseAuthentication();

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
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            Array.Empty<string>()
                        }
                    });

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
