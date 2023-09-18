using Microsoft.AspNetCore.Mvc;
using TestTaskService.Application.Interfaces.Services;

namespace TestTaskService.Api.Controllers;

/// <summary>
/// Контроллер загрузки изображений
/// </summary>
[ApiController]
[Route("api/v1/image")]
public class ImageController : ControllerBase
{
    private readonly IImageService _imageService;

    public ImageController(IImageService imageService)
    {
        _imageService = imageService;
    }

    /// <summary>
    /// Загрузить изображение
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        var result = await _imageService.UploadAsync(file);
        
        return Ok(result);
    }

    /// <summary>
    /// Удалить изображение по ссылке
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] string url)
    {
        await _imageService.DeleteAsync(url);

        return Ok();
    }
}