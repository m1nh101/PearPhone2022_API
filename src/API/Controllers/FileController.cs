using API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/files")]
[Authorize]
public class FileController : ControllerBase
{
	private readonly FileUploader _uploader;

  public FileController(FileUploader uploader)
  {
    _uploader = uploader;
  }

	[HttpPost]
	public async Task<IActionResult> Upload([FromBody] IFormFile file)
	{
		var response = await _uploader.Upload(file);
		return Ok(response);
	}

	[HttpPost]
	[Route("multiples")]
	public async Task<IActionResult> Upload([FromBody] IFormFileCollection files)
	{
		var response = await _uploader.Upload(files);
		return Ok(response);
	}
}