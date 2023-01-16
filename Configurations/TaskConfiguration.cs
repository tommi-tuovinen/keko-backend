using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Keko.Data.Configurations;

internal class TaskConfiguration : IEntityTypeConfiguration<TaskEntity>
{
    public void Configure(EntityTypeBuilder<TaskEntity> builder)
    {
        builder.HasData(
            new TaskEntity
            {
                Id = 1,
                Name = "Some example task",
                CreatedBy = "System"
            },
            new TaskEntity
            {
                Id = 2,
                Name = "Second example task",
                CreatedBy = "System"
            }
        );
    }
}