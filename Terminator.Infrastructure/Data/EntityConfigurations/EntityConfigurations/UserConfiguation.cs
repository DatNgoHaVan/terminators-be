namespace Terminator.Infrastructure.Data.EntityConfigurations
{
    using Terminator.Core.Constants;
    using Terminator.Core.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    /// <summary>
    /// The EF Core configuration for entity <see cref="User"/>
    /// </summary>
    public class UserConfiguation : EntityTypeConfigurationBase<User>
    {
        /// <inheritdoc />
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.ToTable("User", SCHEMA);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.PasswordSalt);

            builder.Property(e => e.PasswordHash);

            builder.Property(e => e.LinkedInAuthToken);

            builder.Property(e => e.LinkToLinkedIn)
                .IsRequired()
                .HasDefaultValue(0);
        }
    }
}
