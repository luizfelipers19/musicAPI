using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace music.Helpers
{
    public static class FileHelper
    {
        [HttpPost]
        public static async Task<string> UploadAlbumImage(IFormFile file)
        {
            string connectionString = @"DefaultEndpointsProtocol=https;AccountName=apimusicsa;AccountKey=2LJKFgqK/7H/T+zlMJo+8zC4eENVobxUtlOQpb2Wz3SNDPffEPziBwaItxPvaq8lucT9wu//jfPXm4zye63iSQ==;EndpointSuffix=core.windows.net";
            string containerName = "albumcover";

            BlobContainerClient blobContainerClient = new BlobContainerClient(connectionString, containerName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(file.FileName);

            var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            await blobClient.UploadAsync(memoryStream);

            return blobClient.Uri.AbsoluteUri;
        
        }

        [HttpPost]
        public static async Task<string> UploadArtistImage(IFormFile file)
        {
            string connectionString = @"DefaultEndpointsProtocol=https;AccountName=apimusicsa;AccountKey=2LJKFgqK/7H/T+zlMJo+8zC4eENVobxUtlOQpb2Wz3SNDPffEPziBwaItxPvaq8lucT9wu//jfPXm4zye63iSQ==;EndpointSuffix=core.windows.net";
            string containerName = "artistimage";

            BlobContainerClient blobContainerClient2 = new BlobContainerClient(connectionString, containerName);
            BlobClient blobClient2 = blobContainerClient2.GetBlobClient(file.FileName);

            var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            await blobClient2.UploadAsync(memoryStream);

            return blobClient2.Uri.AbsoluteUri;

        }

        public static async Task<string> UploadSongImage(IFormFile file)
        {
            string connectionString = @"DefaultEndpointsProtocol=https;AccountName=apimusicsa;AccountKey=2LJKFgqK/7H/T+zlMJo+8zC4eENVobxUtlOQpb2Wz3SNDPffEPziBwaItxPvaq8lucT9wu//jfPXm4zye63iSQ==;EndpointSuffix=core.windows.net";
            string containerName = "songimage";

            BlobContainerClient blobContainerClient2 = new BlobContainerClient(connectionString, containerName);
            BlobClient blobClient2 = blobContainerClient2.GetBlobClient(file.FileName);

            var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            await blobClient2.UploadAsync(memoryStream);

            return blobClient2.Uri.AbsoluteUri;

        }



        //public static async Task<string> UploadSong(IFormFile file)
        //{
        //    string connectionString = @"DefaultEndpointsProtocol=https;AccountName=apimusicsa;AccountKey=2XqcVvo+cjfiN+A9+2GeITIaqDydhN3WLUU/wgnCUnAhvf6yW5zDZgppub1OnUN4PswQa2cguzoaoqVeq8hUVQ==;EndpointSuffix=core.windows.net";
        //    string containerName = "audiofiles";

        //    BlobContainerClient blobContainerClient = new BlobContainerClient(connectionString, containerName);
        //    BlobClient blobClient = blobContainerClient.GetBlobClient(file.FileName);

        //    var memoryStream = new MemoryStream();
        //    await file.CopyToAsync(memoryStream);
        //    memoryStream.Position = 0;
        //    await blobClient.UploadAsync(memoryStream);

        //    return blobClient.Uri.AbsoluteUri;

        //}

    }
}
