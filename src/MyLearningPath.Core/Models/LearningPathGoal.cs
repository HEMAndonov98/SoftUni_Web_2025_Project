using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyLearningPath.Common.Validation;
using MyLearningPath.Core.Models.BaseModel;

namespace MyLearningPath.Core.Models;

public class LearningPathGoal : BaseEfModel<string>
{
    [Required]
    public string UserId { get; set; } = string.Empty;

    [Required]
    [MaxLength(ValidationConstraints.DescriptionMaxLength)]
    public string GoalDescription { get; set; } = string.Empty;

    [ForeignKey(nameof(Skill))]
    public string SkillId { get; set; }

    public Skill Skill { get; set; }

    [ForeignKey(nameof(Topic))]
    public string TopicId { get; set; }
    public Topic Topic { get; set; }

    public LearningPathGoal()
    {
        this.Id = Guid.NewGuid().ToString();
    }
}
