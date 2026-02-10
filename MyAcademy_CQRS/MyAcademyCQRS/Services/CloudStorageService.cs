using Google.Cloud.Storage.V1;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MyAcademyCQRS.Services
{
    public class CloudStorageService
    {
        private readonly StorageClient _storageClient;
        private readonly string _bucketName;

        public CloudStorageService(IConfiguration configuration)
        {
            _bucketName = configuration["GoogleCloud:BucketName"];
            var authFileName = configuration["GoogleCloud:AuthFileName"];

            // Dosya yolunu tam alıyoruz
            var path = Path.Combine(Directory.GetCurrentDirectory(), authFileName);

            // Google'a bağlanıyoruz
            var credential = GoogleCredential.FromFile(path);
            _storageClient = StorageClient.Create(credential);
        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            // Benzersiz isim veriyoruz (image_guid.png gibi)
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                // Buluta yüklüyoruz
                await _storageClient.UploadObjectAsync(_bucketName, fileName, null, memoryStream);
            }

            // Oluşan linki geri döndürüyoruz
            return $"https://storage.googleapis.com/{_bucketName}/{fileName}";
        }
    }
}
