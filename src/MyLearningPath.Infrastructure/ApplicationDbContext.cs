using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using MyLearningPath.Core.Models;
using MyLearningPath.Core.Models.JoinEntities;
using MyLearningPath.Core.Models.User;

namespace MyLearningPath.Infrastructure;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    //base entities
    public DbSet<Category> Category { get; set; }
    public DbSet<Difficulty> Difficulty { get; set; }

    public DbSet<LearningPath> LearningPath { get; set; }

    public DbSet<LearningPathStep> LearningPathStep { get; set; }

    public DbSet<LearningPathGoal> LearningPathGoal { get; set; }

    public DbSet<Resource> Resource { get; set; }

    public DbSet<Skill> Skill { get; set; }

    public DbSet<SubCategory> SubCategory { get; set; }

    public DbSet<Topic> Topic { get; set; }

    //Join table entities
    public DbSet<ResourceSkill> ResourceSkill { get; set; }

    public DbSet<ResourceTopic> ResourceTopic { get; set; }

    public DbSet<UserSkill> UserSkill { get; set; }

    public DbSet<UserLearningGoal> UserLearningGoal { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public ApplicationDbContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ResourceSkill>()
            .HasKey(rs => new { rs.ResourceId, rs.SkillId });

        modelBuilder.Entity<ResourceTopic>()
            .HasKey(rt => new { rt.ResourceId, rt.TopicId });

        modelBuilder.Entity<UserSkill>()
            .HasKey(us => new { us.UserId, us.SkillId });

        modelBuilder.Entity<UserLearningGoal>()
            .HasKey(ul => new { ul.UserId, ul.TopicId });

        //Delete behaviour configuration

        //ResourceSkill
        modelBuilder.Entity<ResourceSkill>()
            .HasOne(rs => rs.Resource)
            .WithMany(r => r.ResourceSkills)
            .HasForeignKey(rs => rs.ResourceId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ResourceSkill>()
            .HasOne(rs => rs.Skill)
            .WithMany(s => s.ResourceSkills)
            .HasForeignKey(rs => rs.SkillId)
            .OnDelete(DeleteBehavior.Cascade);

        //ResourceTopic
        modelBuilder.Entity<ResourceTopic>()
            .HasOne(rt => rt.Resource)
            .WithMany(r => r.ResourceTopics)
            .HasForeignKey(rt => rt.ResourceId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ResourceTopic>()
            .HasOne(rt => rt.Topic)
            .WithMany(t => t.ResourceTopics)
            .HasForeignKey(rt => rt.TopicId)
            .OnDelete(DeleteBehavior.Cascade);

        //UserSkill
        modelBuilder.Entity<UserSkill>()
            .HasOne(us => us.ApplicationUser)
            .WithMany(au => au.UserSkills)
            .HasForeignKey(us => us.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserSkill>()
            .HasOne(us => us.Skill)
            .WithMany(s => s.UserSkills)
            .HasForeignKey(us => us.SkillId)
            .OnDelete(DeleteBehavior.Cascade);

        //UserLearningGoal
        modelBuilder.Entity<UserLearningGoal>()
            .HasOne(ulg => ulg.ApplicationUser)
            .WithMany(au => au.UserLearningGoals)
            .HasForeignKey(ulg => ulg.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserLearningGoal>()
            .HasOne(ulg => ulg.Topic)
            .WithMany(t => t.UserLearningGoals)
            .HasForeignKey(ulg => ulg.TopicId)
            .OnDelete(DeleteBehavior.Cascade);

        //LearningPathStep to LearningPath
        modelBuilder.Entity<LearningPathStep>()
            .HasOne(lps => lps.LearningPath)
            .WithMany(lp => lp.LearningPathSteps)
            .HasForeignKey(lps => lps.LearningPathId)
            .OnDelete(DeleteBehavior.Cascade);

        //Resource to SubCategory
        modelBuilder.Entity<Resource>()
            .HasOne(r => r.SubCategory)
            .WithMany(sc => sc.Resources)
            .HasForeignKey(r => r.SubCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        //SubCategory to Category
        modelBuilder.Entity<SubCategory>()
            .HasOne(sc => sc.Category)
            .WithMany(c => c.SubCategories)
            .HasForeignKey(sc => sc.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        //Resource to Difficulty
        modelBuilder.Entity<Resource>()
            .HasOne(r => r.Difficulty)
            .WithMany(d => d.Resources)
            .HasForeignKey(r => r.DifficultyId)
            .OnDelete(DeleteBehavior.Restrict);

        //TODO Create and configure QuizDetails model
    }
}
