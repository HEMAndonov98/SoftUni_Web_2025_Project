using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyLearningPath.Core.Models;

namespace MyLearningPath.Infrastructure.Configurations;

public class LearningPathStepConfiguration : IEntityTypeConfiguration<LearningPathStep>
{
    public void Configure(EntityTypeBuilder<LearningPathStep> builder)
    {
       builder
            .HasOne(lps => lps.LearningPath)
            .WithMany(lp => lp.LearningPathSteps)
            .HasForeignKey(lps => lps.LearningPathId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}