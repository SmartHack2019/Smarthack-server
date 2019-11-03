using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using smarthack.Data;
using smarthack.Helper.Seeders;

namespace smarthack
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private IHostingEnvironment CurrentEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Database connections
            //            if (CurrentEnvironment.IsDevelopment())


            services.AddDbContext<SmartHackDbContext>(builder =>
            {
                builder.UseMySql(
                "Server=eu-cdbr-west-02.cleardb.net;Database=heroku_63117997832c3e6;User=ba980eb6f8bf25;Password=7d9c388c;");
            });

            services.AddTransient<Seeder>();

            // CORS Policies
            services.AddCors(options =>
            {
                options.DefaultPolicyName = "AppCorsPolicy";
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials().Build();
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, Seeder seeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            //            seeder.SeedTime(); ;
            app.UseCors();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
