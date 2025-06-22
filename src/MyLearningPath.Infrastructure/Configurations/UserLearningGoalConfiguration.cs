using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyLearningPath.Core.Models.JoinEntities;

namespace MyLearningPath.Infrastructure.Configurations;

public class UserLearningGoalConfiguration : IEntityTypeConfiguration<UserLearningGoal>
{
    public void Configure(EntityTypeBuilder<UserLearningGoal> builder)
    {
       builder
            .HasKey(ul => new { ul.UserId, ul.TopicId });


        //UserLearningGoal
       builder
            .HasOne(ulg => ulg.ApplicationUser)
            .WithMany(au => au.UserLearningGoals)
            .HasForeignKey(ulg => ulg.UserId)
            .OnDelete(DeleteBehavior.Cascade);

       builder
            .HasOne(ulg => ulg.Topic)
            .WithMany(t => t.UserLearningGoals)
            .HasForeignKey(ulg => ulg.TopicId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}