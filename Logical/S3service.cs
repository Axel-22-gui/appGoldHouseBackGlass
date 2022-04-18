using Amazon;
using Amazon.Runtime.Internal;
using Amazon.S3;
using Amazon.S3.Transfer;
using System;
using System.Threading.Tasks;

namespace Logical
{
    public class S3service
    {

        private string path = "Files/";
        private readonly IAmazonS3 s3Client;

        public S3service()
        {
            s3Client = new AmazonS3Client("<INSERT YOUR KEY>", "<INSERT YOUR KEY>", "INSERT YOUR SERVER");
        }


        public async Task<ErrorResponse> UploadFileAsync(string archivo)//archivo =imagen.jpeg"
        {
            ErrorResponse error = new ErrorResponse();
            int resp = 0;
            try
            {
                var yourBucketName = "appgoldhouse";
                var yourFilepath = path + archivo;
                var yourfileKey = path + "key/" + archivo;

                var fileTransferUtility = new TransferUtility(s3Client);


                await fileTransferUtility.UploadAsync(yourFilepath, yourBucketName, yourfileKey);
                Console.WriteLine("Upload 2 completed");


            }
            catch (AmazonS3Exception e)
            {

                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return error;
        }


        public ErrorResponse obtenerObject(string ruta)
        {
            ErrorResponse error = new ErrorResponse();

            var yourBucketName = "appgoldhouse";
            var yourfileKey = path + "key/" + ruta;

            var filePah = path + ruta;
            try
            {
                var fileTransferUtility = new TransferUtility(s3Client);
                fileTransferUtility.Download(filePah, yourBucketName, yourfileKey);
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Error encountered on server. Message:'{0}' when writing an object", e.Message);
            }
            catch (Exception e)
            {

                Console.WriteLine("Unknown encountered on server. Message:'{0}' when writing an object", e.Message);
            }
            return error;
        }
    }




}
