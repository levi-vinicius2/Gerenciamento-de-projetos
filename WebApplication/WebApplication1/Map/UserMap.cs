﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UserMap.Map
{
    public class UserMap : IEntityTypeConfiguration<ModelUser.Models.User>
    {
        public void Configure(EntityTypeBuilder<ModelUser.Models.User> builder)
        {
            builder.HasKey(x => x.UserID);
            builder.Property(x => x.name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.email).IsRequired().HasMaxLength(255);
            builder.Property(x => x.password).IsRequired().HasMaxLength(255);
        }
    }
}
