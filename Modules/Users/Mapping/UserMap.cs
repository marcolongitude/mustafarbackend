using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mustafarbackend.Modules.Users.Entities;

namespace mustafarbackend.Modules.Users.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("users");
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.Name).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Password).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Cel).IsRequired().HasMaxLength(25);
            builder.Property(u => u.Permission).IsRequired().HasConversion(
                v => v.ToString(),
                v => (Roles)Enum.Parse(typeof(Roles), v)
                ).HasMaxLength(15);
        }
    }
}
