using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using kip.kirkedata.webservices;
using KipWeb5.Models.Account;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using Telerik.Reporting.Cache.File;
using Telerik.Reporting.Services;


namespace KipWeb5
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            this.WebHostEnvironment = webHostEnvironment;
        }

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment WebHostEnvironment { get; }

        public class MySettings
        {
            public string WebserviceKipUrl { get; set; }

            public string WebserviceServer { get; set; }

            public string WebserviceDatabase { get; set; }
            public string Language { get; set; }

            public KipWebServiceSoapClient KipWSClient = new KipWebServiceSoapClient(new KipWebServiceSoapClient.EndpointConfiguration());

        }

        public static string WebRootPath { get; private set; }

        //public static string MainMenu = "Medarbeider";
        public static string RessursGUID = "";
        public static string kWebRoot = "";
        public static string StandardSprak = "";


        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(corsOption => corsOption.AddPolicy(
                  "ReportingRestPolicy",
                  corsBuilder =>
                  {
                      corsBuilder.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
                  }));

            var reportsPath = System.IO.Path.Combine(this.WebHostEnvironment.ContentRootPath, "wwwroot", "Rapporter");

            services.TryAddSingleton<IReportServiceConfiguration>(sp =>
                new ReportServiceConfiguration
                {
                    // The default ReportingEngineConfiguration will be initialized from appsettings.json or appsettings.{EnvironmentName}.json:
                    ReportingEngineConfiguration = sp.GetService<IConfiguration>(),

                    // In case the ReportingEngineConfiguration needs to be loaded from a specific configuration file, use the approach below:
                    // ReportingEngineConfiguration = ResolveSpecificReportingConfiguration(WebHostEnvironment),
                    HostAppId = "ReportingNet5",
                    Storage = new FileStorage(),
                    ReportSourceResolver = new TypeReportSourceResolver()
                        .AddFallbackResolver(new UriReportSourceResolver(reportsPath))
                });
                       

            services.AddLocalization(options => options.ResourcesPath = "Resources");
            // Add framework services.
            services
                .AddControllersWithViews()
                // Maintain property names during serialization. See:
                // https://github.com/aspnet/Announcements/issues/194
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization()
                .AddNewtonsoftJson(options => { options.SerializerSettings.ContractResolver = new DefaultContractResolver(); });

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedColtures = new List<CultureInfo> { new CultureInfo("de-DE"), new CultureInfo("no-NB") };

                options.DefaultRequestCulture = new RequestCulture(culture: "no-NB", uiCulture: "no-NB");
                options.SupportedCultures = supportedColtures;
                options.SupportedUICultures = supportedColtures;
                //options.RequestCultureProviders = new[] {new RouteDataRequestCultureProvider { IndexOfColutre=1, IndexofUIColture = 1} }
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            });

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            // For å nå tak i User/Identity
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //services.AddDistributedMemoryCache();

            services.AddSession();

            // Add Kendo UI services to the services container
            services.AddKendo();            

            // Lagt til test appsettings
            services.AddOptions();
            services.Configure<MySettings>(Configuration.GetSection("MySettings"));
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

            app.UseSession();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("ReportingRestPolicy");

            var supportedCultures = new[] { new CultureInfo("nb-NO"), new CultureInfo("de-DE") };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("nb-NO"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
