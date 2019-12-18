using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using appVentas.BusinessEntities;
using appVentas.BusinessLogic.Interface;
using appVentas.BusinessLogic.Repositorio;
using appVentas.DataAccess.Interface;
using appVentas.DataAccess.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace VentasApiRestDemo
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<IRepositoryProductoBL<ProductoBE>,RepositoryProductoBL>();
            services.AddScoped<IRepositoryProductoDA<ProductoBE>, RepositoryProductoDA>();
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
                app.UseHsts();
            }

            app.UseStatusCodePages();
            app.UseHttpsRedirection();
            app.UseMvc();


        }
    }
}
