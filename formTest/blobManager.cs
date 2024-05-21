using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace formTest
{
    public class blobManager
    {
        private string connectionStr = "DefaultEndpointsProtocol=https;AccountName=storage2608;AccountKey=4bFTW2bjmXSdoKcwTtLdvFTUdsexC9d0/yogv4TNWGQZz+bIn9RIVbtTH1m1gHcvR8SrPp7VxCxg+AStMmakww==;EndpointSuffix=core.windows.net";
        private BlobServiceClient blobServiceClient;
        private BlobContainerClient containerClient;

        public void initializeBM()
        {
            blobServiceClient = new BlobServiceClient(connectionStr);
        }

        public async void createContainer(string contName)
        {
            String containerName = contName + Guid.NewGuid().ToString();
            containerClient = await blobServiceClient.CreateBlobContainerAsync(containerName);
        }

        public async void testFileUpload(string userData)
        {
            string localPath = "data";
            Directory.CreateDirectory(localPath);

            string fileName = localPath + Guid.NewGuid().ToString();

            string localFileName = "TEST" + Guid.NewGuid().ToString() + ".txt";

            string localFilePath = Path.Combine(localPath, fileName);

            BlobClient blobClient = containerClient.GetBlobClient(fileName);

            Console.WriteLine("Attempting TEST upload...");

            await blobClient.UploadAsync(localFilePath, true);
        }

        public async void getBlobList()
        {
            await foreach(BlobItem item in containerClient.GetBlobsAsync())
            {
                Console.WriteLine("\t" +  item.Name);
            }
        }
    }
}
