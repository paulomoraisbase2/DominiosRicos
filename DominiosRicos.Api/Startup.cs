using DominiosRicos.Dominio.Contratos;
using DominiosRicos.Dominio.ModelosVisualizacao;
using DominiosRicos.Repositorio.Contexto;
using DominiosRicos.Repositorio.Repositorios;
using DominiosRicos.Repositorio.Servicos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Text;
using System.Threading.Tasks;

namespace DominiosRicos.Api
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        private IHostingEnvironment Env { get; }

        public Startup(IHostingEnvironment env)
        {
            Env = env;
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Env.ContentRootPath)
                .AddJsonFile($"appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddCors();

            Console.WriteLine(Configuration.GetConnectionString("DominiosRicosDb"));
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(
            options =>
            {
                options.SerializerSettings.Formatting = Formatting.None;
                options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            }
        );
            services.AddEntityFrameworkProxies();

            services.AddScoped<AuthenticatedUser>();

            services.AddDbContext<DominiosRicosContexto>(option => option
                                                                   .UseLazyLoadingProxies().UseLazyLoadingProxies()
                                                                   .UseNpgsql(Configuration.GetConnectionString("DominiosRicosDb"),
                                                                        m => m.MigrationsAssembly("DominiosRicos.Repositorio"))
                .ReplaceService<IModelCacheKeyFactory, ChaveSchema>());
            //.AddTransient<IDbContextSchema, DbContextSchema>();

            services.AddScoped(typeof(IBaseRepositorio<>), typeof(BaseRepositorio<>));
            //services;

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IAuthServico>(
              new AuthServico(
                  Configuration.GetValue<string>("JWTSecretKey"),
                  Configuration.GetValue<int>("JWTLifespan")
              )
          );

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = false,
                       ValidateAudience = false,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,

                       IssuerSigningKey = new SymmetricSecurityKey(
                           Encoding.UTF8.GetBytes(Configuration.GetValue<string>("JWTSecretKey"))
                       )
                   };

                   options.Events = new JwtBearerEvents
                   {
                       OnMessageReceived = context =>
                       {
                           var accessToken = context.Request.Query["access_token"];

                           var path = context.HttpContext.Request.Path;
                           if (!string.IsNullOrEmpty(accessToken))
                           {
                               context.Token = accessToken;
                           }
                           return Task.CompletedTask;
                       }
                   };
               });
            services.AddSwaggerGen(c =>
            {
                c.DescribeAllEnumsAsStrings();
                c.DescribeStringEnumsInCamelCase();
                c.SwaggerDoc("v1", new Info { Title = "DominiosRicos API", Version = "v1" });
            });
            // In production, the Angular files will be served from this directory
            //services.AddSpaStaticFiles(configuration =>
            //{
            //    configuration.RootPath = "ClientApp";
            //});
        }

        public void Configure(IApplicationBuilder app)
        {
            if (Env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            //app.UseDeveloperExceptionPage();
            app.UseCors(builder => builder
             .WithOrigins("http://localhost:4200", "https://DominiosRicos.com.br", "http://DominiosRicos.com.br/")
             .AllowAnyMethod()
             .AllowAnyHeader()
             .AllowCredentials());
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DominiosRicos API V1"));
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}