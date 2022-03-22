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
using System.Linq;
using System.Threading.Tasks;
using Web.API.Authentication;
using usuarios.UnitOfWork;
using usuarios.DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Web.API.MessageResponse;

namespace Web.API
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
            /*Invocamos la cadena de conexion*/
            services.AddSingleton<IUnitOfWork>(option => new ServicesUnitOfWork(
                Configuration.GetConnectionString("ConexionDB")
                ));

            /*Configuracion starup de autentificacion*/
            var tokenProvider = new JwtProvider("issuer", "audience", "service_2000");
            services.AddSingleton<ITokenProvider>(tokenProvider);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer
                (options => {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = tokenProvider.GetValidationParameters();
                });
            /*indicar la utilizacion de authentication*/

            services.AddAuthorization(auth =>
            {
                auth.DefaultPolicy = new AuthorizationPolicyBuilder().
                AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme).
                RequireAuthenticatedUser().
                Build();
            });

            services.AddControllers();
            /*Consumo web API*/
            services.AddCors(options =>
            options.AddPolicy("AllowWebAppi",
            builder => builder.AllowAnyOrigin().
                             AllowAnyHeader().AllowAnyMethod()));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web.API v1"));
            }
            app.UseAuthentication();
            /*Indicamos al framewor que utilizamos la excepcion handler*/
            app.ConfigureExceptionHandler();
            app.UseRouting();
            /*Consumo web API*/
            app.UseCors("AllowWebAppi");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
