using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Configuration;

namespace Survello.Web.Controllers
{
    public class BlobController : Controller
    {
        private readonly IConfiguration configuration;
        public IActionResult Index()
        {
            return View();
        }
        public BlobController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //TODO: Location to be changed.
        [HttpPost]
        public async Task<IActionResult> Create(IFormFile files)
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

            string systemFileName = files.FileName;

            await cloudBlobContainer.SetPermissionsAsync(permissions);
            await using (var target = new MemoryStream())
            {
                files.CopyTo(target);
                dataFiles = target.ToArray();
            }

            // This also does not make a service call; it only creates a local object.
            CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(systemFileName);
            await cloudBlockBlob.UploadFromByteArrayAsync(dataFiles, 0, dataFiles.Length);

            return View();
        }
    }
}