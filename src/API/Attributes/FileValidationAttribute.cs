using System.ComponentModel.DataAnnotations;
namespace API.Attributes;

public class FileValidationAttribute : ValidationAttribute
{
  private readonly IEnumerable<string> _extensions;

  public FileValidationAttribute(IEnumerable<string> extensions)
  {
    _extensions = extensions;
  }

  protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
  {
    if(IsValid(value))
      return ValidationResult.Success;

    return new ValidationResult("file not allowed");
  }

  public override bool IsValid(object? value)
  {
    var file = value as IFormFile;

    if(file != null)
    {
      var extension = Path.GetExtension(file.FileName);

      return _extensions.Contains(extension.ToLower());
    }

    return false;
  }
}
