﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vault.Core;
using Vault.Core.Entities;
using Vault.Core.Repositories;
using Vault.DataBase;
using Vault.DataBase.Repositories;
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
            services.AddScoped<IRepository<Book>, BookRepository>();
            services.AddScoped<IRepository<Lender>, LenderRepository>();
            services.AddScoped<ILenderRepository, LenderRepository>();
            services.AddScoped<IRepository<LendingRecord>, LendingRecordRepository>();
            services.AddScoped<ILendingRecordRepository, LendingRecordRepository>();
            services.AddScoped<IRepository<Location>, LocationRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();

            services.AddScoped<ICrudInteractor<Book>, BookInteractor>();
            services.AddScoped<IBookInteractor, BookInteractor>();
            services.AddScoped<ICrudInteractor<Lender>, CrudInteractor<Lender>>();
            services.AddScoped<ICrudInteractor<Location>, CrudInteractor<Location>>();
            services.AddScoped<ICrudInteractor<LendingRecord>, CrudInteractor<LendingRecord>>();
            services.AddScoped<ReportInteractor>();

            const string sqlConnectionString = "Server=.;Database=vault13;Trusted_Connection=True;";
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(sqlConnectionString, builder =>
                {
                    builder.MigrationsAssembly("Vault.DataBase");
                }));

            DatabaseSeed.Seed(services.BuildServiceProvider().GetService<DataContext>());
        }
    }
}
