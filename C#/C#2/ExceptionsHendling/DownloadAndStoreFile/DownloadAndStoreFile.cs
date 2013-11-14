using System;
using System.Linq;
using System.Net;

namespace DownloadAndStoreFile
{
    class DownloadAndStoreFile
    {
        static void Main(string[] args)
        {
            using (WebClient webClient = new WebClient())
            {
                Console.Write("Enter URL address: ");
                string addressUrl = Console.ReadLine();
                Console.Write("Enter file name: ");
                string fileName = Console.ReadLine();
                string fullAddress = addressUrl + "/" + fileName;
                try
                {
                    webClient.DownloadFile(fullAddress, fileName);
                }
                catch (WebException)
                {
                    Console.Error.WriteLine("Invalid address.");
                }
                catch (NotSupportedException)
                {
                    Console.Error.WriteLine("The method does not support simultanious downloads.");
                }
            }
        }
    }
}