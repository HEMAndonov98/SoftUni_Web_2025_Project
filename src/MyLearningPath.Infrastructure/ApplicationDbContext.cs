using System.Reflection;
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        //TODO Create and configure QuizDetails model
    }
}
