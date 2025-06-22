using System.ComponentModel.DataAnnotations;
using MyLearningPath.Common.Validation;
using MyLearningPath.Core.Models.BaseModel;
using MyLearningPath.Core.Models.JoinEntities;

namespace MyLearningPath.Core.Models;
/// <summary>
/// The Topic entity represents distinct subjects or areas of knowledge (e.g., "Artificial Intelligence", "Cloud          Computing", "Project Management"). It will be used in relationships with Resource (via ResourceTopic) and ApplicationUser (via UserLearningGoal).
/// </summary>
public class Topic : BaseEfModel<string>
{
    [Required]
    [MaxLength(ValidationConstraints.NameMaxLength)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(ValidationConstraints.ShortDescriptionMaxLength)]
    public string? Description { get; set; }

    public ICollection<UserLearningGoal>? UserLearningGoals { get; set; }

    public ICollection<ResourceTopic> ResourceTopics { get; set; }

    public Topic()
    {
        this.Id = Guid.NewGuid().ToString();
        this.UserLearningGoals = new List<UserLearningGoal>();
        this.ResourceTopics = new List<ResourceTopic>();
    }
}
