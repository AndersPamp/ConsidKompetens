using ConsidKompetens_Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ConsidKompetens_Data.Data
{
  public class DataDbContext : DbContext
  {
    public DbSet<CompetenceModel> CompetenceModels { get; set; }
    public DbSet<ImageModel> ImageModels { get; set; }
    public DbSet<LinkModel> LinkModels { get; set; }
    public DbSet<OfficeModel> OfficeModels { get; set; }
    public DbSet<ProfileModel> ProfileModels { get; set; }
    public DbSet<ProjectModel> ProjectModels { get; set; }
    public DbSet<ProjectProfileRole> ProjectProfileRoles { get; set; }

    public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<ProjectProfileRole>().HasKey(x => new { x.ProjectId, x.ProfileId, x.RoleId });
    }
  }
}