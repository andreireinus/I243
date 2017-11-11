using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vault.Core;
using Vault.Core.Repositories;
using Vault.UI.Admin.Infrastructure;

namespace Vault.UI.Admin
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
            services.AddMvc();

            ConfigureIoc(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private static void ConfigureIoc(IServiceCollection services)
        {
            services.AddScoped<LibraryAdministration>();
            services.AddScoped<ILibraryItemRepository, LibraryItemRepository>();
            services.AddScoped<ILendingRecordRepository, LendingRecordRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
        }
    }
}
