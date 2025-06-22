using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLearningPath.Core.Models.JoinEntities;

public class ResourceTopic
{
    [Required]
    public string ResourceId { get; set; } = null!;
    [InverseProperty(nameof(Resource.ResourceTopics))]
    public Resource Resource { get; set; } = null!;

    [Required]
    public string TopicId { get; set; } = null!;
    [InverseProperty(nameof(Resource.ResourceTopics))]
    public Topic Topic { get; set; } = null!;

    public double RelevanceScore { get; set; }
}
