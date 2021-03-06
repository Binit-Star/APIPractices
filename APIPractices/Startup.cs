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
using Microsoft.EntityFrameworkCore;
using APIPractices.DataAccess;
using APIPractices.Models;
using APIPractices.DataAccess.interfaces;
using APIPractices.Services;
using APIPractices.Services.interfaces;


namespace APIPractices
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
            services.AddDbContextPool<APIPracticesDB>(options=>options.UseSqlServer(Configuration.GetConnectionString("APIPracticesDBConnection")));
            services.AddControllers();

            //services.AddScoped<IGenericRepository<T>,GenericRepository<T>>();
            services.AddScoped<IProductVM, DBProductVM>();
            services.AddScoped<IProducts, DBProducts>();
            services.AddScoped<IHomeServices, HomeServices>();
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
