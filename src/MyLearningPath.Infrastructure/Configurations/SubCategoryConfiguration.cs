using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyLearningPath.Core.Models;

namespace MyLearningPath.Infrastructure.Configurations;

public class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
{
    public void Configure(EntityTypeBuilder<SubCategory> builder)
    {
        //SubCategory to Category
        builder
            .HasOne(sc => sc.Category)
            .WithMany(c => c.SubCategories)
            .HasForeignKey(sc => sc.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}