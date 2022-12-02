using API.Attributes;

namespace API.Helpers;

public class ExcelHelper
{
  private readonly IFormFileCollection _files;
  private readonly FileValidationAttribute _extensions;

  public ExcelHelper(IFormFileCollection files)
  {
    _files = files;
    _extensions = new(new string[] { "xlsx", "xls"});
  }

  private IDictionary<string, IEnumerable<IFormFile>> CheckFile()
  {
    if(_files == null)
      throw new FileNotFoundException("no file attached");

    var validFiles = new List<IFormFile>();
    var inValidFiles = new List<IFormFile>();

    foreach(var file in _files)
    {
      if(_extensions.IsValid(file))
        validFiles.Add(file);
      else
        inValidFiles.Add(file);
    }

    var result = new Dictionary<string, IEnumerable<IFormFile>>();

    result.Add("validFiles", validFiles);
    result.Add("invalidFiles", inValidFiles);

    return result;
  }

  // public IEnumerable<TDestination> ParseExcelToData<TDestination>()
  // {

  // }
}
