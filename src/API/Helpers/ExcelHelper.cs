using API.Attributes;

namespace API.Helpers;

public class ExcelHelper
{
  private readonly IFormFileCollection _files;
  private readonly FileValidationAttribute _extensions;

  public ExcelHelper(IFormFileCollection files)
  {
    _files = files;
    _extensions = new(new string[] { ".xlsx", ".xls"});
  }

  public IDictionary<string, IEnumerable<IFormFile>> CheckFile()
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

  public async Task<IEnumerable<MemoryStream>> ToMemoryStream(IEnumerable<IFormFile> files)
  {
    var streams = new List<MemoryStream>();

    foreach(var file in files)
    {
      var memoryStream = new MemoryStream();

      await file.CopyToAsync(memoryStream);

      streams.Add(memoryStream);
    }

    return streams;
  }
}
