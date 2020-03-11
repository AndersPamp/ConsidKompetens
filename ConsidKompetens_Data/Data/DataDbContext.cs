using ConsidKompetens_Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsidKompetens_Data.Data
{
  public class DataDbContext : DbContext
  {
    public DbSet<ImageModel> ImageModels { get; set; }
    public DbSet<OfficeModel> OfficeModels { get; set; }
    public DbSet<ProfileModel> ProfileModels { get; set; }
    public DbSet<ProjectModel> ProjectModels { get; set; }
    public DbSet<ProjectProfileRole> ProjectProfileRoles { get; set; }
    public DbSet<CompetenceModel> CompetenceModels { get; set; }
    public DbSet<TimePeriod> TimePeriods { get; set; }

    public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<ProjectProfileRole>().HasKey(x => new { x.ProjectModelId, x.ProfileModelId, x.RoleModelId });
      //modelBuilder.SeedData();
    }
  }
}