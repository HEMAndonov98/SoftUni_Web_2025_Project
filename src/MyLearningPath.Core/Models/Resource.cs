using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyLearningPath.Common.Validation;
using MyLearningPath.Core.Models.BaseModel;
using MyLearningPath.Core.Models.Enums;
using MyLearningPath.Core.Models.JoinEntities;

namespace MyLearningPath.Core.Models;

public class Resource : BaseEfModel<string>
{
    [Required]
    [MaxLength(ValidationConstraints.NameMaxLength)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [MaxLength(ValidationConstraints.DescriptionMaxLength)]
    public string Description { get; set; } = string.Empty;

    [Required]
    [MaxLength(ValidationConstraints.UrlMaxLength)]
    public string Url { get; set; } = string.Empty;

    [Required]
    public ResourceType ResourceType { get; set; }

    [Required]
    [ForeignKey(nameof(SubCategory))]
    public string SubCategoryId { get; set; } = null!;
    public SubCategory SubCategory { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(Difficulty))]
    public string DifficultyId { get; set; } = null!;
    public Difficulty Difficulty { get; set; } = null!;

    //TODO add inverse property to help fluent API
    [InverseProperty(nameof(ResourceSkill.Resource))]
    public ICollection<ResourceSkill>? ResourceSkills { get; set; }
    [InverseProperty(nameof(ResourceTopic.Resource))]
    public ICollection<ResourceTopic>? ResourceTopics { get; set; }
    [InverseProperty(nameof(LearningPathStep.Resource))]
    public ICollection<LearningPathStep>? LearningPathSteps { get; set; }

    // public QuizzDetails? QuizzDetails { get; set; }

    public Resource()
    {
        this.Id = Guid.NewGuid().ToString();
        this.ResourceSkills = new List<ResourceSkill>();
        this.ResourceTopics = new List<ResourceTopic>();
        this.LearningPathSteps = new List<LearningPathStep>();
    }
}
