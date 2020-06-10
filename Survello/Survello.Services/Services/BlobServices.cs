using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Auth;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Configuration;
using Survello.Services.ConstantMessages;
using Survello.Services.Services.Contracts;
using System;
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
            try
            {
                //string blobStorageConnectionString = configuration.GetValue<string>("BlobConnectionString");
                const string accountName = "survelloapp";
                const string key = "4HKx3C6843+mdf+YTvxDzLQv8zbEkvgRC+koUoOBdZxIQWwfQK6A6ovUv3O1cAxP0lG8It7WrR7ZoQwybt9hGQ==";

                CloudStorageAccount cloudStorageAccount = new CloudStorageAccount(new StorageCredentials(accountName, key), true);
                CloudBlobClient client = cloudStorageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = client.GetContainerReference("documents");

                byte[] dataFiles;

                string systemFileName = $"{questionId}_{corelationToken}_{files.FileName}"; //questionId?


                await container.CreateIfNotExistsAsync();
                await container.SetPermissionsAsync(new BlobContainerPermissions()
                {
                    PublicAccess = BlobContainerPublicAccessType.Blob
                });


                await using (var target = new MemoryStream())
                {
                    files.CopyTo(target);
                    dataFiles = target.ToArray();
                }

                // This also does not make a service call; it only creates a local object.
                CloudBlockBlob cloudBlockBlob = container.GetBlockBlobReference(systemFileName);
                await cloudBlockBlob.UploadFromByteArrayAsync(dataFiles, 0, dataFiles.Length);

                return cloudBlockBlob.Uri.AbsoluteUri.ToString();
            }
            catch (Exception)
            {
                throw new Exception(ExceptionMessages.BlobError);
            }
        }
    }
}
