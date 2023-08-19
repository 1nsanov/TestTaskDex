using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTaskService.Domain.Entities.Users;

namespace TestTaskService.Infrastructure.Data.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasKey(u => u.Id);

        builder
            .Property(u => u.Login)
            .HasMaxLength(16)
            .IsRequired();
        builder
            .HasIndex(u => u.Login)
            .IsUnique();
        
        builder.OwnsOne(u => u.FullName, fn =>
        {
            fn.Property(f => f.Family)
                .HasMaxLength(50)
                .IsRequired();
            fn.Property(f => f.Given)
                .HasMaxLength(50)
                .IsRequired();
            fn.Property(f => f.Middle)
                .HasMaxLength(50)
                .IsRequired();
        });

        builder
            .Property(u => u.IsAdmin)
            .IsRequired();
        
        builder
            .HasMany(u => u.Advertisements)
            .WithOne(a => a.User)
            .HasForeignKey(a => a.UserId);
    }
}