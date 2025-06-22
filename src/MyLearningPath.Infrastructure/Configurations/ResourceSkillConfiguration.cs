using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyLearningPath.Core.Models.JoinEntities;

namespace MyLearningPath.Infrastructure.Configurations;

public class ResourceSkillConfiguration : IEntityTypeConfiguration<ResourceSkill>
{
    public void Configure(EntityTypeBuilder<ResourceSkill> builder)
    {
        builder.HasKey(rs => new { rs.ResourceId, rs.SkillId });
        
       builder
            .HasOne(rs => rs.Resource)
            .WithMany(r => r.ResourceSkills)
            .HasForeignKey(rs => rs.ResourceId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(rs => rs.Skill)
            .WithMany(s => s.ResourceSkills)
            .HasForeignKey(rs => rs.SkillId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}