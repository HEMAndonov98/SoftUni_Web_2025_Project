using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using MyLearningPath.Core.Models.Enums;
using MyLearningPath.Core.Models.User;

namespace MyLearningPath.Core.Models.JoinEntities;

public class UserLearningGoal
{
    [Required]
    public string UserId { get; set; } = null!;
    [InverseProperty(nameof(ApplicationUser.UserLearningGoals))]
    public ApplicationUser ApplicationUser { get; set; } = null!;

    [Required]
    public string TopicId { get; set; } = null!;

    [InverseProperty(nameof(Topic.UserLearningGoals))]
    public Topic Topic { get; set; } = null!;

    [Required]
    public LearningGoalStatus learningGoalStatus { get; set; } = LearningGoalStatus.NotStarted;


    public DateTime DateSet { get; set; } = DateTime.UtcNow;
    public DateTime? DateCompleted { get; set; }
}
