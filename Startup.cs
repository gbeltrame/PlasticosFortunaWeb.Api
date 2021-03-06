using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PlasticosFortunaWeb.Api.Models;
using Microsoft.Extensions.Options;
using PlasticosFortunaWeb.Api.Services;

namespace PlasticosFortunaWeb.Api
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
            services.Configure<PlasticosFortunaDBSettings>(
             Configuration.GetSection(nameof(PlasticosFortunaDBSettings)));
            services.AddSingleton<IPlasticosFortunaDBSettings>(sp =>
                sp.GetRequiredService<IOptions<PlasticosFortunaDBSettings>>().Value);
            services.AddSingleton<TestService>();
            services.AddSingleton<OrdenTrabajoService>();
            services.AddSingleton<HistorialOrdenTrabajoService>();
            services.AddSingleton<PersonaService>();
            services.AddSingleton<StockService>();
            services.AddSingleton<HistorialStockService>();
            services.AddSingleton<OpcionService>();
            services.AddMvc(
                options =>
                {
                    options.Filters.Add(typeof(ValidateModelStateAttribute));
                }
            );
            services.AddControllers();
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
        }
    }
}
