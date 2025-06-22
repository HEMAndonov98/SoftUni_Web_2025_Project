using Microsoft.AspNetCore.Identity;
using MyLearningPath.Core.Models.JoinEntities;

namespace MyLearningPath.Core.Models.User;

public class ApplicationUser : IdentityUser
{
    public string? LearningStyle { get; set; }

    public ICollection<LearningPath>? LearningPaths { get; set; }

    public ICollection<UserSkill>? UserSkills { get; set; }

    public ICollection<UserLearningGoal>? UserLearningGoals { get; set; }

    public ApplicationUser()
    {
        this.LearningPaths = new List<LearningPath>();
        this.UserSkills = new List<UserSkill>();
        this.UserLearningGoals = new List<UserLearningGoal>();
    }
}
