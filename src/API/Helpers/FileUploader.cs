namespace API.Helpers;

public class FileUploader
{
	private readonly IWebHostEnvironment _env;
  private readonly string _path;
  public FileUploader(IWebHostEnvironment env)
  {
    _env = env;
		_path = Path.Combine(_env.ContentRootPath, "wwwroot", "images");
    CreateDirectoryIfNotExist();
  }

  private void CreateDirectoryIfNotExist()
  {
    if (!Directory.Exists(_path))
      Directory.CreateDirectory(_path);
  }

  public async Task<IEnumerable<string>> Upload(IFormFileCollection files)
  {
    var urls = new List<string>();

    foreach (var file in files)
    {
      var url = await Upload(file);
      urls.Add(url);
    }

    return urls;
  }

  public async Task<string> Upload(IFormFile file)
  {
    var filePath = Path.Combine(_path, file.FileName);

    using var stream = File.Create(filePath);
    await file.CopyToAsync(stream);

    return $"~/wwwroot/images/{file.FileName}";
  }
}