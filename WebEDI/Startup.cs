using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using WebEDI.Respository.Entity;
using WebEDI.Respository.Interface;
using WebEDI.Respository.Services;
using WebEDI.Common.Core;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using Microsoft.Extensions.Options;
using System.Reflection;
using WebEDI.Utility;
namespace WebEDI
{
    public class Startup
    {
        private readonly IHostingEnvironment _environment;
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            _environment = environment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = SameSiteMode.Strict;
                options.HttpOnly = HttpOnlyPolicy.Always;
                options.Secure = _environment.IsDevelopment()
                  ? CookieSecurePolicy.None : CookieSecurePolicy.Always;
            });
            services.AddLogging();
            services.Configure<FormOptions>(options =>
            {
                options.ValueCountLimit = int.MaxValue;
            });
            services.AddEntityFrameworkNpgsql().AddDbContext<webedidbContext>(options => options.UseNpgsql(Base64.Decode(Configuration.GetConnectionString("WebEDIConnectionString"))));
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(
                    options =>
                    {
                        options.LoginPath = "/Account/Login/";
                        options.Cookie.HttpOnly = true;
                        options.Cookie.SecurePolicy = _environment.IsDevelopment()
                          ? CookieSecurePolicy.None : CookieSecurePolicy.Always;
                        options.Cookie.SameSite = SameSiteMode.Lax;
                        options.Cookie.Name = "WebEDI.AuthCookieAspNetCore";
                        options.LogoutPath = "/Account/Logout";
                        options.AccessDeniedPath = "/AccessDenied/AccessDenied";
                    }
                );
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IShiiresakiService, ShiiresakiService>();
            services.AddScoped<INouhinmeisaiService, NouhinmeisaiService>();
            services.AddScoped<IOrderUserService, OrderUserService>();

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IViewRenderService, ViewRenderService>();
            services.AddScoped<IOrderDetailService, OrderDetailService>();

            services.AddMemoryCache();
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.Configure<RequestLocalizationOptions>(options =>
                    {
                        var supportedCultures = new[]
                        {
                        new CultureInfo("en-US"),
                        new CultureInfo("ja-jp")
                    };

                options.DefaultRequestCulture = new RequestCulture("ja-jp");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
             .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix, options => { options.ResourcesPath = "Resources"; })
             .AddDataAnnotationsLocalization(options =>
             {
                 options.DataAnnotationLocalizerProvider = (type, factory) =>
                 {
                     var assemblyName = new AssemblyName(typeof(Resources).GetTypeInfo().Assembly.FullName);
                     return factory.Create("Resources", assemblyName.Name);
                 };
             });
            //Configure to determine the current culture for a request

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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            var localizationOption = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(localizationOption.Value);
            app.Use(async (context, next) =>
            {
                var principal = context.User as ClaimsPrincipal;
                var accessToken = principal?.Claims
                  .FirstOrDefault(c => c.Type == "access_token");

                if (accessToken != null)
                {
                    Log.Logger.Debug(accessToken.Value);
                }

                await next();
            });
        
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
