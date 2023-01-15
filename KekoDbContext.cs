using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Keko.Data;

public class KekoDbContext : IdentityDbContext
{
    public KekoDbContext(DbContextOptions<KekoDbContext> options) : base(options)
    {
        
    }

    public DbSet<TaskEntity> Tasks { get; set; }
}