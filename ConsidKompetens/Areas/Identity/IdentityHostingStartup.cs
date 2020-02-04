using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(ConsidKompetens_Web.Areas.Identity.IdentityHostingStartup))]
namespace ConsidKompetens_Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}