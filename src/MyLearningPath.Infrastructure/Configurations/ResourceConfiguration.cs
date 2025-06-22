using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyLearningPath.Core.Models;

namespace MyLearningPath.Infrastructure.Configurations;

public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
{
    public void Configure(EntityTypeBuilder<Resource> builder)
    {
        //Resource to SubCategory
        builder
            .HasOne(r => r.SubCategory)
            .WithMany(sc => sc.Resources)
            .HasForeignKey(r => r.SubCategoryId)
            .OnDelete(DeleteBehavior.Restrict);
        
        //Resource to Difficulty
        builder
            .HasOne(r => r.Difficulty)
            .WithMany(d => d.Resources)
            .HasForeignKey(r => r.DifficultyId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}