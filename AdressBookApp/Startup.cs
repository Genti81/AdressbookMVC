using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AdressBookApp.Data;
using AdressBookApp.Models;
using AdressBookApp.Services;
using Microsoft.AspNetCore.Mvc;
using AdressBookApp.Interface;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace AdressBookApp
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

            ITimeProvider myFakeTimeProvider = new FakeTimeProvider();
            myFakeTimeProvider.Now = new DateTime(2017, 1, 1);
            services.AddSingleton<ITimeProvider>(new RealTimeProvider());

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("DefaultConnection"));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, CoolEmailSender>();

            //services.AddLocalization(options =>
            //{
            //    options.ResourcesPath = "";
            //});
            services.AddLocalization();
            services.AddMvc();
            //.AddViewLocalization()
            //.AddDataAnnotationsLocalization();
            //services.Configure<MvcOptions>(options =>
            //{
            //    //options.Filters.Add(new RequireHttpsAttribute());
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            ApplicationDbContext context, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            //app.Use((contxt, next) =>
            //{
            //    var cultureQuery = contxt.Request.Query["culture"];
            //    if (!string.IsNullOrWhiteSpace(cultureQuery))
            //    {
            //        var culture = new CultureInfo(cultureQuery);
            //        CultureInfo.CurrentCulture = culture;
            //        CultureInfo.CurrentUICulture = culture;
            //    }
            //    else
            //    {
            //        var culture = new CultureInfo("en-US");
            //        CultureInfo.CurrentCulture = culture;
            //        CultureInfo.CurrentUICulture = culture;
            //    }
            //    return next();
            //});

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //    List<CultureInfo> supportedCultures = new List<CultureInfo>
            //    {
            //        new CultureInfo("sq-AL"),
            //        new CultureInfo("sq"),
            //        new CultureInfo("al"),
            //        new CultureInfo("en")
            //};

            //    app.UseRequestLocalization(new RequestLocalizationOptions
            //    {
            //        DefaultRequestCulture = new RequestCulture("sq-AL"),
            //        SupportedCultures = supportedCultures,
            //        SupportedUICultures = supportedCultures
            //    });
            app.Use((request, next) =>
            {
                var svse = new CultureInfo("sv-SE");
                System.Threading.Thread.CurrentThread.CurrentCulture = svse;
                System.Threading.Thread.CurrentThread.CurrentUICulture = svse;
                return next();
            });
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=about}/{id?}/{slug?}");
            });

            SeedData.Seed(context, userManager, roleManager);
        }
    }
}
