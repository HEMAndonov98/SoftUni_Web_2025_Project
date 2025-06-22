using System.ComponentModel.DataAnnotations;

using MyLearningPath.Core.Constants;
using MyLearningPath.Core.Models.BaseModel;

namespace MyLearningPath.Core.Models;

public class Category : BaseEfModel<string>
{
    [Required]
    [MaxLength(ValidationConstraints.NameMaxLength)]
    public string Name { get; set; } = string.Empty;

    public ICollection<SubCategory>? SubCategories { get; set; }

    public Category()
    {
        this.Id = Guid.NewGuid().ToString();
        this.SubCategories = new List<SubCategory>();
    }
}
