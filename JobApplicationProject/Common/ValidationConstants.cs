namespace JobApplicationProject.Common;

public static class ValidationConstants
{
    public const int ProjectNameMaxLength = 10;


}
public static class ValidationMessages
{
    public const string ProjectNameRequired = "Proje adı zorunludur.";
    public const string TaskNameRequired = "Task adı zorunludur.";
    public static readonly string ProjectNameLength = $"Proje adı en fazla {ValidationConstants.ProjectNameMaxLength} karakter olmalıdır.";
}