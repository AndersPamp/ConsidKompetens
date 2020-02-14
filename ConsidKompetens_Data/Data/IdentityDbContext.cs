using Microsoft.EntityFrameworkCore;

namespace ConsidKompetens_Data.Data
{
  public class IdentityDbContext : Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext
  {
    public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
        : base(options)
    {
    }
  }
}
