using System.ComponentModel.DataAnnotations;

namespace MyLearningPath.Core.Models.BaseModel;
/// <summary>
/// Base entity framework core model from which all entitites in our project will inherit from
/// </summary>
/// <typeparam name="TId">TId is the type we want to use for our primary key</typeparam>
public abstract class BaseEfModel<TId>
{
    [Key]
    public TId Id { get; set; } = default!;

    /// <summary>
    /// Flag for soft deleted entities
    /// </summary>
    public bool IsDeleted { get; set; } = false;
    /// <summary>
    /// Time of entity soft deletion for recovery
    /// </summary>
    public DateTime? DeletedAt { get; set; }

    /// <summary>
    /// Time when the entity was created
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    /// <summary>
    /// Last Time model was modified
    /// </summary>
    public DateTime? LastModifiedAt { get; set; }
}
