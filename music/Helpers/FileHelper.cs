using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace music.Helpers
{
    public static class FileHelper
    {

        public static async Task<string> UploadImage(IFormFile file)
        {
            string connectionString = @"DefaultEndpointsProtocol=https;AccountName=apimusicsa;AccountKey=2XqcVvo+cjfiN+A9+2GeITIaqDydhN3WLUU/wgnCUnAhvf6yW5zDZgppub1OnUN4PswQa2cguzoaoqVeq8hUVQ==;EndpointSuffix=core.windows.net";
            string containerName = "albumcover";

            BlobContainerClient blobContainerClient = new BlobContainerClient(connectionString, containerName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(file.FileName);

            var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            await blobClient.UploadAsync(memoryStream);

            return blobClient.Uri.AbsoluteUri;
        
        }

    }
}
