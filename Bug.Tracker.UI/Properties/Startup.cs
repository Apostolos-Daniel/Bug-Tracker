using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Bug.Tracker.UI.Data;
using Bug.Tracker.BugCreator;
using Bug.Tracker.BugReader;
using Bug.Tracker.BugUpdater;
using Bug.Tracker.UserReader;
using Bug.Tracker.CreateUser;
using Bug.Tracker.UserUpdater;

namespace Bug.Tracker.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddHttpClient("bugTrackerClient", client =>
            {
                client.BaseAddress = new Uri("https://localhost:44342/api/");
            });
            //.AddTransient<IBugCreator, BugCreator.BugCreator>();
            services.AddScoped<IBugCreator, BugCreator.BugCreator>();
            services.AddScoped<IBugReader, BugReader.BugReader>();
            services.AddScoped<IBugUpdater, BugUpdater.BugUpdater>();
            services.AddScoped<IUserReader, UserReader.UserReader>();
            services.AddScoped<IUserUpdater, UserUpdater.UserUpdater>();
            services.AddScoped<IUserCreator, CreateUser.UserCreator>();
            services.AddSingleton<WeatherForecastService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
