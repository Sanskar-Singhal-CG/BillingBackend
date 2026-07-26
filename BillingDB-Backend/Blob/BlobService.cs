using Azure.Storage.Blobs;

//I used AI for this code -_-

namespace BillingDB_Backend.Blob
{
    public class BlobService
    {
        private readonly BlobContainerClient _container;

        public BlobService(IConfiguration config)
        {
            var connectionString = config["Blob:ConnectionString"];
            var containerName = config["Blob:ContainerName"];

            var serviceClient = new BlobServiceClient(connectionString);
            _container = serviceClient.GetBlobContainerClient(containerName);

            _container.CreateIfNotExists();
        }

        public async Task<string> UploadAsync(IFormFile file)
        {
            var blobName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var blobClient = _container.GetBlobClient(blobName);

            using var stream = file.OpenReadStream();
            await blobClient.UploadAsync(stream, overwrite: true);

            return blobClient.Uri.ToString();
        }

        public async Task<Stream?> GetSignatureAsync(string url)
        {
            if (string.IsNullOrEmpty(url)) return null;

            var blobName = Path.GetFileName(new Uri(url).LocalPath);
            var blobClient = _container.GetBlobClient(blobName);

            var response = await blobClient.DownloadStreamingAsync();
            return response.Value.Content;
        }
    }
}