using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using smarthack.Data;

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
            if (CurrentEnvironment.IsDevelopment())
                services.AddDbContext<SmartHackDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("SmartHackDbContextConnection")));
            //services.AddDbContext<SmartHackDbContext>(builder =>
            //{
            //    builder.UseMySql(
            //    "Server=eu-cdbr-west-02.cleardb.net;Database=heroku_1c3f591c0e17d07;User=b5977c722a69d6;Password=a7c61ba3;");
            //});

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

            app.UseCors();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
