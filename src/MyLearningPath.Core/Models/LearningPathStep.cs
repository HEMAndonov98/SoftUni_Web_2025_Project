using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyLearningPath.Core.Models.BaseModel;

namespace MyLearningPath.Core.Models;
/// <summary>
/// Represents a single step in a learning path. A learning path can have many steps and a LearningPathStep can be a part of many Resources
/// </summary>
public class LearningPathStep : BaseEfModel<string>
{
    [Required]
    [Range(1, int.MaxValue)]
    public int Order { get; set; }

    [Required]
    [ForeignKey(nameof(LearningPath))]
    public string LearningPathId { get; set; } = null!;
    [InverseProperty(nameof(LearningPath.LearningPathSteps))]
    public LearningPath LearningPath { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(Resource))]
    public string ResourceId { get; set; } = null!;
    [InverseProperty(nameof(Resource.LearningPathSteps))]
    public Resource Resource { get; set; } = null!;


    public LearningPathStep()
    {
        this.Id = Guid.NewGuid().ToString();
    }
}
