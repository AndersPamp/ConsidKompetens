using System;
using System.Linq;
using System.Threading.Tasks;
using ConsidKompetens_Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsidKompetens_Data.Data
{
  public class UserDataContext : DbContext
  {
    public DbSet<EmployeeUserModel> EmployeeUsers { get; set; }
    public DbSet<CompetenceModel> CompetenceModels { get; set; }
    public DbSet<OfficeModel> OfficeModels { get; set; }
    public DbSet<ProjectModel> ProjectModels { get; set; }

    public UserDataContext(DbContextOptions<UserDataContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
    }

    public override int SaveChanges()
    {
      AddAuditInfo();
      return base.SaveChanges();
    }

    public async Task<int> SaveChangesAsync()
    {
      AddAuditInfo();
      return await base.SaveChangesAsync();
    }

    private void AddAuditInfo()
    {
      var entries = ChangeTracker.Entries().Where(x =>
        x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
      foreach (var entry in entries)
      {
        if (entry.State == EntityState.Added)
        {
          ((BaseEntity)entry.Entity).Created = DateTime.UtcNow;
        }
        ((BaseEntity)entry.Entity).Modified = DateTime.UtcNow;
      }
    }
  }
}