using IMC.Tax.Interfaces;
using IMC.Tax.Services.Factories;
using IMC.Tax.Services.Services;
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

namespace IMC.Tax.Calculator.API
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "IMC.Tax.Calculator.API", Version = "v1" });
            });
            services.AddHttpClient("TaxJarClient", client =>
            {
                client.BaseAddress = new Uri(@"https://api.taxjar.com/v2/");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + "5da2f821eee4035db4771edab942a4cc");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
            });
            services.AddTransient<ITaxCalculatorProviderService, TaxJarCalculatorProviderService>();
            services.AddTransient<ITaxCalculatorProviderFactory, TaxCalculatorProviderFactory>();
            services.AddTransient<ITaxJarApi, TaxJarApi>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IMC.Tax.Calculator.API v1"));
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
