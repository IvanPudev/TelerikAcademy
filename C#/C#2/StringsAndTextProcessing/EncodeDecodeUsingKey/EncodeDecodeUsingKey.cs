using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncodeDecodeUsingKey
{
    class Program
    {
        static string TextEncryptor(string textToEncrypt, string key)
        {
            StringBuilder cryptedText = new StringBuilder();
            int length = textToEncrypt.Length;
            int keyLength = key.Length;
            int keyIndex = 0;
            
            for (int index = 0 ;index < length; index++)
            {
                if (keyIndex == keyLength)
                {
                    keyIndex = 0;
                }
                cryptedText.Append((char)(textToEncrypt[index] ^ key[keyIndex]));
                keyIndex++;
            }
            return cryptedText.ToString();
        }

        static void Main(string[] args)
        {
            string encryptionText = "Some text for encryption";
            string encodingKey = "ABC";
            string encryptedText = TextEncryptor(encryptionText, encodingKey);

            Console.WriteLine("Encrypted: {0}", encryptedText);
            Console.WriteLine("Decrypted: {0}", TextEncryptor(encryptedText, encodingKey));
        }
    }
}
