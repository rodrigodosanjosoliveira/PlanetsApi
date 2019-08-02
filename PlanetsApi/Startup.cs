using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlanetsApi.Repository;
using PlanetsApi.Repository.Context;
using PlanetsApi.Repository.Interfaces;
using PlanetsApi.Service;

namespace PlanetsApi
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
            services.AddDbContext<MyContext>(opt => opt.UseInMemoryDatabase("PlanetDb"));

            services.AddTransient<IPlanetService, PlanetService>();
            services.AddTransient<IPlanetRepository, PlanetRepository>();
            services.AddScoped<MyContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerDocument();

            services.AddMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseOpenApi();
            app.UseSwaggerUi3();
             
            app.UseMvc();
        }
    }
}
