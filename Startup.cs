using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using TripTracker.Data;
using TripTracker.Models;

namespace TripTracker
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
            // using Microsoft.EntityFrameworkCore;
            //dotnet add package Microsoft.EntityFrameworkCore.Sqlite
            
            services.AddDbContext<TripContext>( o=>
                o.UseSqlite("Data Source = TripDb.db"));
            
            services.AddTransient<Repository>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(o =>
            o.SwaggerDoc("v1", new Info { Title = "Trip Tracker", Version = "v1"}));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, TripContext tripContext)
        {

            
            //swagger przed usmvc bo sie popsuje
            app.UseSwagger();
            if(env.IsDevelopment() || env.IsStaging())
            {
            app.UseSwaggerUI(o =>
                o.SwaggerEndpoint("/swagger/v1/swagger.json","Trip Tracker v1"));
            };

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
            app.UseMvc();
            tripContext.SeedData(app.ApplicationServices);
        }
    }
}
