using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyLearningPath.Core.Models.JoinEntities;

namespace MyLearningPath.Infrastructure.Configurations;

public class ResourceTopicConfiguration : IEntityTypeConfiguration<ResourceTopic>
{
    public void Configure(EntityTypeBuilder<ResourceTopic> builder)
    {
        builder.HasKey(rt => new { rt.ResourceId, rt.TopicId });

        builder
            .HasOne(rt => rt.Resource)
            .WithMany(r => r.ResourceTopics)
            .HasForeignKey(rt => rt.ResourceId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(rt => rt.Topic)
            .WithMany(t => t.ResourceTopics)
            .HasForeignKey(rt => rt.TopicId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}