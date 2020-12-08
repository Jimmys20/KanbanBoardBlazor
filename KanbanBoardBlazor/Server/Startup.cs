using AutoMapper;
using KanbanBoardBlazor.Server.Common.Configuration;
using KanbanBoardBlazor.Server.Dal;
using KanbanBoardBlazor.Server.Dal.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SQW;
using SQW.Interfaces;
using System.Linq;

namespace KanbanBoardBlazor.Server
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            #region SQW configuration
            var databaseOptionsSection = configuration.GetSection("databaseOptions");
            var databaseOptions = databaseOptionsSection.Get<DatabaseOptions>();
            services.Configure<DatabaseOptions>(databaseOptionsSection);

            var oraConfig = new SQWOraConfig
            {
                host = databaseOptions.host,
                instance = databaseOptions.instance,
                userName = databaseOptions.username,
                password = databaseOptions.password
            };

            var oraSequenceGenerator = new SQWOraSequenceGenerator();
            var oraWorker = new SQWOraWorker(oraConfig, oraSequenceGenerator);
            services.AddSingleton<ISQWWorker>(oraWorker);
            #endregion

            services.AddSingleton<ProjectRepository>();

            services.AddAutoMapper(typeof(Startup));

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
