using System.ComponentModel.DataAnnotations;
using MyLearningPath.Common.Validation;
using MyLearningPath.Core.Models.BaseModel;

namespace MyLearningPath.Core.Models;
/// <summary>
/// his entity will represent the various levels of challenge for your resources (e.g., "Beginner", "Intermediate", "Advanced"). Your Resource model already has a foreign key pointing to Difficulty.
/// </summary>
public class Difficulty : BaseEfModel<string>
{
    [Required]
    [MaxLength(ValidationConstraints.NameMaxLength)]
    public string LevelName { get; set; } = string.Empty;

    [MaxLength(ValidationConstraints.ShortDescriptionMaxLength)]
    public string? Description { get; set; }

    public ICollection<Resource>? Resources { get; set; }

    public Difficulty()
    {
        this.Id = Guid.NewGuid().ToString();
        this.Resources = new List<Resource>();
    }
}
