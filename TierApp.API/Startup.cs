using App.API.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TierApp.API.Extensions;

namespace TierApp.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        readonly string MyHollyOrigins = "_myHollyOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        [System.Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            var secretKey = Configuration.GetSection("AppSettings:SecretKey").Value;

            services.AddControllers();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton(Configuration);

            services.AddAutoMapper(typeof(Startup));
            services.AddScopedServices();
            services.AddAuthenticationServices(secretKey);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TierApp API", Version = "v1" });
            });
        }

        [System.Obsolete]
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors(MyHollyOrigins);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TierApp V1");
            });
        }
    }
}