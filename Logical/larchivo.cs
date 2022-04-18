using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logical
{
    public class larchivo
    {
        private string path = "./Files/";


        public void guardarArchivo(byte[] dataArray, string name)
        {
            string fileName = path + name;

            using (FileStream
                fileStream = new FileStream(fileName, FileMode.Create))
            {
                // Write the data to the file, byte by byte.
                for (int i = 0; i < dataArray.Length; i++)
                {
                    fileStream.WriteByte(dataArray[i]);
                }
                // Set the stream position to the beginning of the file.
                fileStream.Seek(0, SeekOrigin.Begin);

                // Read and verify the data.
                for (int i = 0; i < fileStream.Length; i++)
                {
                    if (dataArray[i] != fileStream.ReadByte())
                    {
                        Console.WriteLine("Error writing data.");
                        return;
                    }
                }
            }
        }


        public string descargarArchivo(string ruta)
        {
            string pathSource = path + ruta;
            Console.WriteLine(pathSource);
            // Specify a file to read from and to create.
            //   string pathSource = ruta;
            byte[] bytes = null;
            try
            {

                using (FileStream fsSource = new FileStream(pathSource,
                    FileMode.Open, FileAccess.Read))
                {

                    // Read the source file into a byte array.
                    bytes = new byte[fsSource.Length];
                    int numBytesToRead = (int)fsSource.Length;
                    int numBytesRead = 0;
                    while (numBytesToRead > 0)
                    {
                        // Read may return anything from 0 to numBytesToRead.
                        int n = fsSource.Read(bytes, numBytesRead, numBytesToRead);

                        // Break when the end of the file is reached.
                        if (n == 0)
                            break;

                        numBytesRead += n;
                        numBytesToRead -= n;
                    }
                }
            }
            catch (FileNotFoundException ioEx)
            {
                Console.WriteLine(ioEx.Message);
            }
            return Convert.ToBase64String(bytes);
        }
    }
}
