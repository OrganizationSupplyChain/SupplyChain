using System;
using Invoice_Discounting.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;

namespace Invoice_Discounting
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
            services.Configure<FormOptions>(options =>
            {
                options.ValueCountLimit = int.MaxValue;
            });
            services.AddControllersWithViews();
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IDatabaseCalls, DatabaseCalls>();
            services.AddScoped<IApiImplementation, ApiImplementation>();
            services.AddScoped<IActiveDirectoryService, ActiveDirectoryService>();
            services.AddScoped<IPayment, Payment>();
            services.AddScoped<IDashboardcontent, Dashboardcontent>();

            // services.AddSingleton<IFormCollection, FormCollection>();
            _ = services.AddMvc(
                options =>
                {
                    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                })
                .AddRazorRuntimeCompilation()
                .AddJsonOptions(options =>
                options.JsonSerializerOptions.PropertyNamingPolicy = null);

            services.AddAntiforgery(options =>
            {
                options.HeaderName = "__RequestVerificationToken";
                options.SuppressXFrameOptionsHeader = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            });
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(5);
                //Requires app to be accessed via HTTPS. To be commented if running in development env.
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;

            });

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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Frame-Options", "DENY");
                await next();
            });
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
