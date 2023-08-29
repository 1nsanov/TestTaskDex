using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTaskService.Domain.Entities.Advertisements;

namespace TestTaskService.Infrastructure.Data.Configuration;

public class AdvertisementConfiguration : IEntityTypeConfiguration<Advertisement>
{
    public void Configure(EntityTypeBuilder<Advertisement> builder)
    {
        builder
            .HasKey(u => u.Id);
        
        builder
            .Property(a => a.Number)
            .IsRequired();

        builder
            .HasIndex(a => a.Number)
            .IsUnique();
        
        builder
            .Property(a => a.Title)
            .HasMaxLength(100)
            .IsRequired();
        
        builder
            .HasIndex(a => a.Title)
            .HasName("IX_Advertisement_Title");
        
        builder
            .Property(a => a.Text)
            .HasMaxLength(500)
            .IsRequired();
        
        builder
            .Property(a => a.Rate)
            .IsRequired();
        
        builder
            .Property(a => a.ExpireDate)
            .IsRequired();

        builder
            .Property(a => a.ImageUrl)
            .HasMaxLength(2000);
         
        builder
            .HasOne(a => a.User)
            .WithMany(u => u.Advertisements)
            .HasForeignKey(a => a.UserId);
    }
}