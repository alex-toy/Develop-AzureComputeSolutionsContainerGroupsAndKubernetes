using Azure.Storage.Blobs;
using System;

namespace BlobService
{
    internal class Program
    {
        private static string blob_connection_string = "DefaultEndpointsProtocol=https;AccountName=persstingdatasa;AccountKey=lmFQG5/hsQwCsu8gUV73PkpVCa+ImlBhnx87Wv/NL6OGmX2dBAAmsLSrVqg4gWdab7Wmi3Vd5lEO+AStmLTD7g==;EndpointSuffix=core.windows.net";
        private static string container_name = "data";
        private static string local_blob = "/app/data/Courses.json";
        private static string blob_name = "Courses.json";

        static void Main(string[] args)
        {

            BlobServiceClient _client = new BlobServiceClient(blob_connection_string);

            BlobContainerClient _container_client = _client.GetBlobContainerClient(container_name);

            BlobClient _blob_client = _container_client.GetBlobClient(blob_name);

            Console.WriteLine("Initiating download");

            _blob_client.DownloadTo(local_blob);
        }
    }
}
