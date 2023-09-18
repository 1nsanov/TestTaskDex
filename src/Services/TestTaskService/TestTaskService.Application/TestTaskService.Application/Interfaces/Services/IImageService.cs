using Microsoft.AspNetCore.Http;

namespace TestTaskService.Application.Interfaces.Services;

public interface IImageService
{
    Task<string> UploadAsync(IFormFile file);

    Task DeleteAsync(string url);
}