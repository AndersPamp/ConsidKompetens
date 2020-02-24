using System.ComponentModel.DataAnnotations;
using System.Text;
using ConsidKompetens_Core.Interfaces;
using ConsidKompetens_Data.Data;
using ConsidKompetens_Services.DataServices;
using ConsidKompetens_Services.Helpers;
using ConsidKompetens_Services.IdentityServices;
using ConsidKompetens_Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace ConsidKompetens_Web
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
      services.AddDbContext<IdentityDbContext>(options =>
        options.UseSqlServer(
          Configuration.GetConnectionString("DefaultConnection")));

      services.AddDbContext<DataDbContext>(options =>
        options.UseSqlServer(
          Configuration.GetConnectionString("DataConnection")));

      services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<IdentityDbContext>();
      //services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
      services.Configure<IdentityOptions>(options =>
      {
        options.Password.RequiredLength = 8;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequireUppercase = true;
        options.Password.RequireLowercase = true;
        options.SignIn.RequireConfirmedEmail = false;
      });
      
      services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
      services.AddScoped<ILoginService, LoginService>();
      services.AddScoped<IRegisterService, RegisterService>();
      services.AddScoped<IProfileDataService, ProfileDataService>();
      services.AddScoped<ISearchDataService, SearchService>();
      services.AddScoped<IOfficeDataService, OfficeDataService>();
      services.AddScoped<ICompetenceDataService, CompetenceDataService>();
      services.AddScoped<IProjectDataService, ProjectDataService>();
      services.AddScoped<ValidationAttribute, AllowedExtensionsAttribute>();
      services.AddScoped<ValidationAttribute, MaxFileSizeAttribute>();

      services.AddControllers(config =>
      {
        var policy = new AuthorizationPolicyBuilder()
          .RequireAuthenticatedUser()
          .Build();
        config.Filters.Add(new AuthorizeFilter(policy));
      });

        // Appsetting -> ImageSection.cs
        // IOption<ImageSection>
        var securitySettingsSections = Configuration.GetSection("AppSettings");
        services.Configure<AppSettings>(securitySettingsSections);

        services.Configure<AppSettings>(Configuration.GetSection("AllowedFileExtensions"));
        services.Configure<AppSettings>(Configuration.GetSection("MaxFileSize"));
        services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
        services.Configure<AppSettings>(Configuration.GetSection("ImageFilePath"));

        var appSettings = securitySettingsSections.Get<AppSettings>();
        var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(x =>
      {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      }).AddJwtBearer(token =>
      {
        token.RequireHttpsMetadata = false;
        token.SaveToken = true;
        token.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(key),
          ValidateIssuer = false,
          ValidateAudience = false
        };
      });

      services.AddSpaStaticFiles(configuration =>
      {
        configuration.RootPath = "ClientApp/build";
      });

      services.AddOutputCaching();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseDatabaseErrorPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseStaticFiles();
      app.UseSpaStaticFiles();
      app.UseRouting();
      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Login}/{action=Post}/{id?}");
        endpoints.MapControllerRoute(
                  name: "register",
                  pattern: "{controller=Register}/{action=Post}/{id?}");
      });

      app.UseSpa(spa =>
      {
        spa.Options.SourcePath = "ClientApp";
        spa.Options.DefaultPage = "/index.html";

        if (env.IsDevelopment())
        {
          spa.UseReactDevelopmentServer(npmScript: "start");
        }
      });
      app.UseOutputCaching();
    }
  }
}
