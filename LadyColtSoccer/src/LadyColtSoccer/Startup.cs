﻿// <author>
//   Tony Morris
// </author>
// <modified>
//   2015-08-29 10:56 PM
// </modified>
// <created>
//   2015-08-23 11:58 AM
// </created>

namespace LadyColtSoccer
{
    using Microsoft.AspNet.Builder;
    using Microsoft.AspNet.Diagnostics;
    using Microsoft.AspNet.Hosting;
    using Microsoft.Framework.Configuration;
    using Microsoft.Framework.DependencyInjection;
    using Microsoft.Framework.Logging;
    using Microsoft.Framework.Runtime;

    public class Startup
    {
        public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
        {
            // Setup configuration sources.

            var builder = new ConfigurationBuilder(appEnv.ApplicationBasePath).AddJsonFile("config.json").AddJsonFile($"config.{env.EnvironmentName}.json", true);

            if (env.IsDevelopment())
            {
                // This reads the configuration keys from the secret store.
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();
            }
            builder.AddEnvironmentVariables();
            this.Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(this.Configuration.GetConfigurationSection("AppSettings"));
            services.AddMvc();
        }

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.MinimumLevel = LogLevel.Information;
            loggerFactory.AddConsole();

            // Configure the HTTP request pipeline.

            // Add the following to the request pipeline only in development environment.
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseErrorPage(ErrorPageOptions.ShowAll);
            }
            else
            {
                // Add Error handling middleware which catches all application specific errors and
                // sends the request to the following path or controller action.
                app.UseErrorHandler("/Home/Error");
            }

            // Add static files to the request pipeline.
            app.UseStaticFiles();

            // Add authentication middleware to the request pipeline. You can configure options such as Id and Secret in the ConfigureServices method.
            // For more information see http://go.microsoft.com/fwlink/?LinkID=532715
            // app.UseFacebookAuthentication();
            // app.UseGoogleAuthentication();
            // app.UseMicrosoftAccountAuthentication();
            // app.UseTwitterAuthentication();

            // Add MVC to the request pipeline.
            app.UseMvc(
                routes =>
                    {
                        routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");

                        // Uncomment the following line to add a route for porting Web API 2 controllers.
                        // routes.MapWebApiRoute("DefaultApi", "api/{controller}/{id?}");
                    });
        }
    }
}