using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using MyLearningPath.Core.Models.User;
using MyLearningPath.Core.Models.Enums;

namespace MyLearningPath.Core.Models.JoinEntities;

public class UserSkill
{
    [Required]
    public string UserId { get; set; } = null!;
    [InverseProperty(nameof(ApplicationUser.UserSkills))]
    public ApplicationUser ApplicationUser { get; set; } = null!;

    [Required]
    public string SkillId { get; set; } = null!;

    [InverseProperty(nameof(Skill.UserSkills))]
    public Skill Skill { get; set; } = null!;

    [Required]
    public ProficiencyLevel ProficiencyLevel { get; set; } = ProficiencyLevel.Begginer;
}
