using Azure.Storage.Blobs;
using System.IO;

namespace BlobServiceSecret
{
    internal class Program
    {
        private static string container_name = "data";
        private static string local_blob = "/app/data/Courses.json";
        private static string blob_name = "Courses.json";
        private static string secretname = "/app/secrets/storage-connection";

        static void Main(string[] args)
        {
            string blob_connection_string = File.ReadAllText(secretname);

            BlobServiceClient _client = new BlobServiceClient(blob_connection_string);

            BlobContainerClient _container_client = _client.GetBlobContainerClient(container_name);


            BlobClient _blob_client = _container_client.GetBlobClient(blob_name);

            _blob_client.DownloadTo(local_blob);
        }
    }
}
