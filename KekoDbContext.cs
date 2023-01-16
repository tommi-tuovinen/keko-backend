using Keko.Data.Configurations;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Keko.Data;

public class KekoDbContext : IdentityDbContext
{
    public KekoDbContext(DbContextOptions<KekoDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new TaskConfiguration());
    }

    public DbSet<TaskEntity> Tasks { get; set; }
}