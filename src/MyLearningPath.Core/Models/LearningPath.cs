using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using MyLearningPath.Core.Constants;
using MyLearningPath.Core.Models.BaseModel;
using MyLearningPath.Core.Models.User;

namespace MyLearningPath.Core.Models;
/// <summary>
/// The LearningPath entity will represent a curated sequence of LearningPathSteps, typically created by a user.
/// </summary>
public class LearningPath : BaseEfModel<string>
{
    [Required]
    [MaxLength(ValidationConstraints.TitleMaxLength)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(ValidationConstraints.ShortDescriptionMaxLength)]
    public string? Description { get; set; }

    public DateTime GenerationDate { get; set; } = DateTime.UtcNow;
    public DateTime LastModified { get; set; } = DateTime.UtcNow;

    [Required]
    [ForeignKey(nameof(ApplicationUser))]
    public string UserId { get; set; } = null!;
    [InverseProperty(nameof(ApplicationUser.LearningPaths))]
    public ApplicationUser ApplicationUser { get; set; } = null!;

    public ICollection<LearningPathStep> LearningPathSteps { get; set; }

    public LearningPath()
    {
        this.Id = Guid.NewGuid().ToString();
        this.LearningPathSteps = new List<LearningPathStep>();
    }
}
