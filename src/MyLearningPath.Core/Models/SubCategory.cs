using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyLearningPath.Common.Validation;
using MyLearningPath.Core.Models.BaseModel;

namespace MyLearningPath.Core.Models;

public class SubCategory : BaseEfModel<string>
{
    [Required]
    [MaxLength(ValidationConstraints.NameMaxLength)]
    public string Name { get; set; } = string.Empty;

    [ForeignKey(nameof(Category))]
    public string CategoryId { get; set; } = string.Empty;

    public Category Category { get; set; } = null!;

    public ICollection<Resource>? Resources { get; set; }

    public SubCategory()
    {
        this.Id = Guid.NewGuid().ToString();
    }
}
