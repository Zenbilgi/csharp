using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeCourse.Services.Catalog.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FreeCourse.Services.Catalog
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

            services.AddAutoMapper(typeof(Startup));

            services.AddControllers();

            // Options pattern in ASP.NET Core
            // Is registered as a Singleton and can be injected into any service lifetime.
            //
            // Config dosyasını
            // Options pattern: Configleri sınıf üstüne alarak okuma işlemidir.
            // Settings klasöründeki nesneleri bu yüzden oluşturduk.
            // DatabaseSettings sınıfını herhangi bir yerde construct edebiliriz
            // DI olarak eklemek istiyoruz.
            services.Configure<DatabaseSettings>(Configuration.GetSection("DatabaseSettings"));

            services.AddSingleton<IDatabaseSettings>(serviceProvider => {
                return serviceProvider.GetRequiredService<Microsoft.Extensions.Options.IOptions<DatabaseSettings>>().Value;
            });

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
