using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstarct;
using Business.Concrete;
using Core.DependencyResolves;
using Core.Extensions;
using Core.Utilities.IOC;
using Core.Utilities.Security.Encyrption;
using Core.Utilities.Security.JWT;
using DataAccess.Abstarct;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI
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
            //AutoFac, Ninject,CastleWindsor, StructureMap, lighInject,DryInject --> IoC Container
            services.AddControllers();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddCors();

            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });
            //olu�turdu�umuz coremodule ba��ml�l���n� ekle
            //dependencyresolves ad�nda extensions olu�turduk
            //servicecollectionextensions alt�nda olu�turduk
            services.AddDependencyResolves(new ICoreModule[] { new CoreModule() });
            //services.AddSingleton<IProductService, ProductManager>();
            //services.AddSingleton<IProductDal, EfProductDal>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //burdan istek gelirse get post put ne gelirse gelsin izin ver
            app.UseCors(builder=>builder.WithOrigins("http://localhost:4200").AllowAnyHeader());
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
