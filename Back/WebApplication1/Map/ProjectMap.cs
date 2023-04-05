using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectMap.Map
{
    public class ProjectMap : IEntityTypeConfiguration<ModelProject.Models.Project>
    {
        public void Configure(EntityTypeBuilder<ModelProject.Models.Project> builder)
        {
            builder.HasKey(x => x.projectID);
            builder.Property(x => x.projectName).IsRequired().HasMaxLength(255);
            builder.Property(x => x.adminUserID).IsRequired().HasMaxLength(255);
        }
    }
}
