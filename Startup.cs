using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using Susteni.Models.Account;
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
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Susteni.Services;
using Susteni.Utils;
using Susteni.DAL;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Identity.Web;
using Microsoft.Graph;
using Kendo.Mvc;

namespace Susteni
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
            public string Server { get; set; }
            public string Database { get; set; }
            public string Language { get; set; }
            public string WebserviceUrl { get; set; }

        }

        public static string WebRootPath { get; private set; }
        public static string StandardSprak = "";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.Unspecified;
                // Handling SameSite cookie according to https://docs.microsoft.com/en-us/aspnet/core/security/samesite?view=aspnetcore-3.1
                options.HandleSameSiteCookieCompatibility();
            });

            services.AddCors(corsOption => corsOption.AddPolicy(
                  "ReportingRestPolicy",
                  corsBuilder =>
                  {
                      corsBuilder.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
                  }));

            services.AddOptions();

            //AZURE START

            //services.AddSingleton<IMSGraphService, MSGraphService>();

            //services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
            //        .AddMicrosoftIdentityWebApp(options =>
            //        {
            //            Configuration.Bind("AzureAd", options);

            //            options.Events.OnTokenValidated = async context =>
            //            {
            //                string tenantId = context.SecurityToken.Claims.FirstOrDefault(x => x.Type == "tid" || x.Type == "http://schemas.microsoft.com/identity/claims/tenantid")?.Value;
            //            };
            //            options.Events.OnAuthenticationFailed = (context) =>
            //            {
            //                if (context.Exception != null && context.Exception is UnauthorizedTenantException)
            //                {
            //                    context.Response.Redirect("/Home/UnauthorizedTenant");
            //                    context.HandleResponse(); // Suppress the exception
            //                }

            //                return Task.FromResult(0);
            //            };
            //        }
            //        )
            //        .EnableTokenAcquisitionToCallDownstreamApi()
            //        .AddMicrosoftGraph(Configuration.GetSection("Graph"))
            //        .AddInMemoryTokenCaches();

            //services.AddControllersWithViews(options =>
            //{
            //    var policy = new AuthorizationPolicyBuilder()
            //        .RequireAuthenticatedUser()
            //       .Build();
            //    options.Filters.Add(new AuthorizeFilter(policy));
            //});

            //AZURE SLUTT

            services.AddRazorPages();

            services.AddLocalization(options => options.ResourcesPath = "Resources");

            // Add framework services.
            services.AddControllersWithViews()
                // Maintain property names during serialization. See:
                // https://github.com/aspnet/Announcements/issues/194
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver())
                ;

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization()
                .AddNewtonsoftJson(options => { options.SerializerSettings.ContractResolver = new DefaultContractResolver(); })
                ;

            services.Configure<FormOptions>(x =>
            {
                x.ValueLengthLimit = int.MaxValue;
                x.MultipartBodyLengthLimit = int.MaxValue;
            });

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

            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(480);
            });

            // Add Kendo UI services to the services container
            services.AddKendo(
                x => { x.IconType = IconType.Font; }
                );

            // Lagt til test appsettings
            services.AddOptions();
            services.Configure<MySettings>(Configuration.GetSection("MySettings"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var provider = new FileExtensionContentTypeProvider();
            provider.Mappings[".vds"] = "application/octet-stream";

            app.UseStaticFiles(new StaticFileOptions
            {
                ContentTypeProvider = provider
            });


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

            app.UseAuthentication();
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

            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Path.Combine(env.ContentRootPath, "App_Data"));

            // serve static linked files (JavaScript and CSS for the editor)
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(
                   System.IO.Path.Combine(System.IO.Path.GetDirectoryName(
                       System.Reflection.Assembly.GetEntryAssembly().Location),
                       "TXTextControl.Web")),
                RequestPath = "/TXTextControl.Web"
            });

            // enable Web Sockets
            app.UseWebSockets();

            // attach the Text Control WebSocketHandler middleware
            app.UseMiddleware<TXTextControl.Web.WebSocketMiddleware>();
        }
    }
}
