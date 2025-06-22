using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyLearningPath.Core.Models.JoinEntities;

namespace MyLearningPath.Infrastructure.Configurations;

public class UserSkillConfiguration : IEntityTypeConfiguration<UserSkill>
{
    public void Configure(EntityTypeBuilder<UserSkill> builder)
    {
        builder
            .HasKey(us => new { us.UserId, us.SkillId });

        builder
            .HasOne(us => us.ApplicationUser)
            .WithMany(au => au.UserSkills)
            .HasForeignKey(us => us.UserId)
            .OnDelete(DeleteBehavior.Cascade);

       builder
            .HasOne(us => us.Skill)
            .WithMany(s => s.UserSkills)
            .HasForeignKey(us => us.SkillId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}