namespace MyLearningPath.Core.Constants;
/// <summary>
/// Model constraint validation static class
/// </summary>
public static class ValidationConstraints
{
    public const int NameMaxLength = 100;
    public const int TitleMaxLength = 255; // For resource titles

    // Description Lengths
    public const int DescriptionMaxLength = 1000; // General long description
    public const int ShortDescriptionMaxLength = 500; // Shorter descriptions (e.g., for skills, categories)

    public const int UrlMaxLength = 2048;

    //Rating range constraints
    public const int RatingMinRange = 0;
    public const int RatingMaxRange = 10;
}
