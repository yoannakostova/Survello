using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Configuration;
using Survello.Services.Services.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;



namespace Survello.Services.Services
{
    public class BlobServices : IBlobServices
    {
        private readonly IConfiguration configuration;
        public BlobServices(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<string> UploadAsync(IFormFile files, Guid corelationToken, Guid questionId)
        {
            string blobStorageConnectionString = configuration.GetValue<string>("BlobConnectionString");

            byte[] dataFiles;

            // Retrieve storage account from connection string.
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobStorageConnectionString);

            // Create the blob client.
            CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();

            // Retrieve a reference to a container.
            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference("documents");

            BlobContainerPermissions permissions = new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            };

            string systemFileName = $"{questionId}.{corelationToken}.{files.FileName}"; //questionId?

            await cloudBlobContainer.SetPermissionsAsync(permissions);
            await using (var target = new MemoryStream())
            {
                files.CopyTo(target);
                dataFiles = target.ToArray();
            }

            // This also does not make a service call; it only creates a local object.
            CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(systemFileName);
            await cloudBlockBlob.UploadFromByteArrayAsync(dataFiles, 0, dataFiles.Length);

            var filePath = cloudBlockBlob.Uri.AbsoluteUri;

            return filePath;
        }
    }
}
