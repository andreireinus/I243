using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Vault.Core;
using Vault.Core.Entities;
using Vault.Core.Repositories;
using Vault.DataBase;
using Vault.DataBase.Repositories;
using Vault.UI.AdminRestApi.Infrastructure;

namespace Vault.UI.AdminRestApi
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Vault API", Version = "v1" });
            });

            ConfigureIoc(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseSwagger();
        }

        private void ConfigureIoc(IServiceCollection services)
        {
            services.AddScoped<IRepository<Book>, BookRepository>();
            services.AddScoped<IRepository<Lender>, LenderRepository>();
            services.AddScoped<IRepository<LendingRecord>, LendingRecordRepository>();
            services.AddScoped<ICrudInteractor<Book>, CrudInteractor<Book>>();
            services.AddScoped<ICrudInteractor<Lender>, CrudInteractor<Lender>>();
            services.AddScoped<ICrudInteractor<LendingRecord>, CrudInteractor<LendingRecord>>();

            var sqlConnectionString = "Server=.;Database=vault13;Trusted_Connection=True;";

            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(sqlConnectionString, builder =>
                    {
                        builder.MigrationsAssembly("Vault.DataBase");
                    }));

            DatabaseSeed.Seed(services.BuildServiceProvider().GetService<DataContext>());
        }
    }
}
