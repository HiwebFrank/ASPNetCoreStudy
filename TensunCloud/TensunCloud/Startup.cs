using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TensunCloud.Models;
using TensunCloud.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Encodings;
using Microsoft.Extensions.WebEncoders;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace TensunCloud
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<TensunContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
                        
            //以下代码解决中文乱码问题
            //services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.All));
            services.Configure<WebEncoderOptions>(options =>
            {
                options.TextEncoderSettings = new TextEncoderSettings(UnicodeRanges.All);
            });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<TensunContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => {
                    policy.RequireClaim("SysAdmin", "SysAdmin");
                    policy.RequireClaim("ProductAdmin", "ProductAdmin");
                    policy.RequireClaim("ProjectAdmin", "ProjectAdmin");
                    policy.RequireClaim("CustomerAdmin", "CustomerAdmin");
                });
                options.AddPolicy("SysAdmin", policy => policy.RequireClaim("SysAdmin", "SysAdmin"));
                options.AddPolicy("ProductAdmin", policy => policy.RequireClaim("ProductAdmin", "ProductAdmin"));
                options.AddPolicy("ProjectAdmin", policy => policy.RequireClaim("ProjectAdmin", "ProjectAdmin"));
                options.AddPolicy("CustomerAdmin", policy => policy.RequireClaim("CustomerAdmin", "CustomerAdmin"));
                options.AddPolicy("Readers", policy => policy.RequireClaim("Readers", "Readers"));
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, TensunContext context)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseIdentity();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            DbInitializer.Initialize(context);
        }
    }
}
