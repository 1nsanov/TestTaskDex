using Firebase.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using TestTaskService.Application.Interfaces.Services;

namespace TestTaskService.Infrastructure.Services;

public class ImageService : IImageService
{
    private readonly IConfiguration _config;

    public ImageService(IConfiguration config)
    {
        _config = config;
    }

    public async Task<string> UploadAsync(IFormFile file)
    {
        if (file == null || file.Length <= 0)
            throw new FileLoadException("File is invalid or empty!");

        if (file.Length > 10 * 1024 * 1024)
            throw new FileLoadException("File size exceeds the allowed limit (10 MB)!");

        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
        var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
        if (!allowedExtensions.Contains(fileExtension))
            throw new FileLoadException("Invalid file extension!");
        
        var stream = file.OpenReadStream();
        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        var firebaseStorage = new FirebaseStorage(_config["FirebaseStorage:Bucket"]);
        var imageUrl = await firebaseStorage
            .Child(fileName)
            .PutAsync(stream);
            
        return imageUrl;
    }

    public async Task DeleteAsync(string url)
    {
        var firebaseStorage = new FirebaseStorage(_config["FirebaseStorage:Bucket"]);

        var fileName = url
            .Split("/").Last()
            .Split("?").First();
            
        await firebaseStorage
            .Child(fileName)
            .DeleteAsync();
    }
}