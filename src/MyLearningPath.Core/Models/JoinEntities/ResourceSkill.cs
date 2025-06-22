using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyLearningPath.Common.Validation;


namespace MyLearningPath.Core.Models.JoinEntities;

public class ResourceSkill
{
    [Required]
    public string ResourceId { get; set; } = null!;

    [InverseProperty(nameof(Resource.ResourceSkills))]
    public Resource Resource { get; set; } = null!;

    [Required]
    public string SkillId { get; set; } = null!;

    [InverseProperty(nameof(Resource.ResourceSkills))]
    public Skill Skill { get; set; } = null!;

    [Range(ValidationConstraints.RatingMinRange, ValidationConstraints.RatingMaxRange)]
    public int Rating { get; set; }
}
