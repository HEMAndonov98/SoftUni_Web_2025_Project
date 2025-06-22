using System.ComponentModel.DataAnnotations;
using MyLearningPath.Common.Validation;
using MyLearningPath.Core.Models.BaseModel;
using MyLearningPath.Core.Models.JoinEntities;

namespace MyLearningPath.Core.Models;

public class Skill : BaseEfModel<string>
{
    [Required]
    [MaxLength(ValidationConstraints.NameMaxLength)]
    public string Name { get; set; } = string.Empty;

    public ICollection<UserSkill>? UserSkills { get; set; }
    public ICollection<ResourceSkill>? ResourceSkills { get; set; }

    public Skill()
    {
        this.Id = Guid.NewGuid().ToString();
        this.UserSkills = new List<UserSkill>();
        this.ResourceSkills = new List<ResourceSkill>();
    }
}
