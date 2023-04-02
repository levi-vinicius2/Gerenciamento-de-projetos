using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskMap.Map
{
    public class TaskMap : IEntityTypeConfiguration<ModelTask.Models.Task>
    {
        public void Configure(EntityTypeBuilder<ModelTask.Models.Task> builder)
        {
            builder.HasKey(x => x.taskID);
            builder.Property(x => x.taskName).IsRequired().HasMaxLength(255);
            builder.Property(x => x.observation).HasMaxLength(255);
            builder.Property(x => x.responsableUserID).HasMaxLength(255);
            builder.Property(x => x.startDate).IsRequired().HasMaxLength(255);
        }
    }
}
