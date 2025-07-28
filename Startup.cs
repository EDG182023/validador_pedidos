using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ValidadorPedidos.Services;
using ValidadorPedidos.Utils;

namespace ValidadorPedidos
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            // Set connection string from configuration if available
            var conn = configuration.GetConnectionString("Saadis");
            if (!string.IsNullOrEmpty(conn))
            {
                Configuracion.SaadisConnectionString = conn;
            }
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton(new SaadisDbService(Configuracion.SaadisConnectionString));
            services.AddHttpClient<SaadApiService>();
            services.AddHttpClient<StockApiService>();
            services.AddSingleton<ExcelService>();
            services.AddSingleton<ValidacionService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
