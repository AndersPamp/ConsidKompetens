using System.IO;
using System.Text;
using AutoMapper;
using ConsidKompetens_Core.Interfaces;
using ConsidKompetens_Data.Data;
using ConsidKompetens_Services.DataServices;
using ConsidKompetens_Services.Helpers;
using ConsidKompetens_Services.IdentityServices;
using ConsidKompetens_Services.Interfaces;
using ConsidKompetens_Services.Mapping;
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
using Microsoft.Extensions.FileProviders;
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

      services.AddDefaultIdentity<IdentityUser>()
        .AddEntityFrameworkStores<IdentityDbContext>()
        .AddDefaultTokenProviders();
      //services.AddIdentity<IdentityUser, IdentityRole>(options => { options.ClaimsIdentity.UserIdClaimType = "UserID";}).AddEntityFrameworkStores<IdentityDbContext>();
      services.Configure<IdentityOptions>(options =>
      {
        options.Password.RequiredLength = 8;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequireUppercase = true;
        options.Password.RequireLowercase = true;
        options.SignIn.RequireConfirmedEmail = true;
      });

      services.AddAutoMapper(typeof(ModelToDTOProfile));
      services.AddAutoMapper(typeof(DTOToModelProfile));

      services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
      services.AddScoped<ILoginService, LoginService>();
      services.AddScoped<IRegisterService, RegisterService>();
      services.AddScoped<IProfileDataService, ProfileDataService>();
      services.AddScoped<ISearchDataService, SearchService>();
      services.AddScoped<IOfficeDataService, OfficeDataService>();
      services.AddScoped<IProjectDataService, ProjectDataService>();
      services.AddScoped<IImageDataService, ImageDataService>();

      services.AddControllers(config =>
      {
        var policy = new AuthorizationPolicyBuilder()
          .RequireAuthenticatedUser()
          .Build();
        config.Filters.Add(new AuthorizeFilter(policy));
      });

      var appSettingsSection = Configuration.GetSection("AppSettings");
      services.Configure<AppSettings>(appSettingsSection);

      var appSettings = appSettingsSection.Get<AppSettings>();

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
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
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
      app.UseStaticFiles(new StaticFileOptions
      {
        FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "../ConsidKompetens_Data/ProfileImages")),
        RequestPath = "/ProfileImages"
      });
      app.UseStaticFiles(new StaticFileOptions
      {
        FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "../ConsidKompetens_Data/Icons")),
        RequestPath = "/Icons"
      });
      app.UseSpaStaticFiles(new StaticFileOptions
      {
        FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "../ConsidKompetens_Data/ProfileImages")),
        RequestPath = "/ProfileImages"
      });
      app.UseSpaStaticFiles(new StaticFileOptions
      {
        FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "../ConsidKompetens_Data/Icons")),
        RequestPath = "/Icons"
      });
      if (env.IsDevelopment())
      {
        app.UseSpaStaticFiles(
          new StaticFileOptions
          {
            FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "../ConsidKompetens_Data/Email"))
          });
      }
      app.UseRouting();
      app.UseAuthentication();
      app.UseAuthorization();
      app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
      #region UseEndpoints
      //app.UseEndpoints(endpoints =>
      //{
      //  endpoints.MapControllerRoute(
      //            name: "default",
      //            pattern: "{controller=Login}/{action=Login}/{id?}");
      //  endpoints.MapControllerRoute(
      //            name: "register",
      //            pattern: "{controller=Register}/{action=Register}/{id?}");
      //  endpoints.MapControllerRoute(
      //    name: "profile",
      //    pattern: "{controller=Profile}/");
      //}); 
      #endregion

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
