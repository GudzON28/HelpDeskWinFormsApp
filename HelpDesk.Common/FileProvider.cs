using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace HelpDesk.Common
{
    public static class FileProvider
    {
        private static string conf = "cnf.dat";
        private static byte[] key =
        {
            0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
            0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
        };

        public static bool Exist(string fileName)
        {
            return File.Exists(fileName);
        }

        public static void EncryptPut(string text)
        {
            using (var fs = new FileStream(conf, FileMode.OpenOrCreate))
            {
                using (var aes = Aes.Create())
                {
                    aes.Key = key;

                    byte[] iv = aes.IV;
                    fs.Write(iv, 0, iv.Length);

                    using (var cryptoStream = new CryptoStream(fs, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        using (var ecryptWriter = new StreamWriter(cryptoStream))
                        {
                            ecryptWriter.WriteLine(text);
                        }
                    }
                }
            }
        }

        public static string DecryptGet()
        {
            string text;

            using (var fs = new FileStream(conf, FileMode.Open))
            {
                using (var aes = Aes.Create())
                {
                    var numBytesToRead = aes.IV.Length;
                    var numBytesRead = 0;
                    var iv = new byte[numBytesToRead];

                    while (numBytesToRead > 0)
                    {
                        int n = fs.Read(iv, numBytesRead, numBytesToRead);

                        if (n == 0)
                        {
                            break;
                        }

                        numBytesRead += n;
                        numBytesToRead -= n;
                    }

                    using(var cryptoStream = new CryptoStream(fs, aes.CreateDecryptor(key, iv), CryptoStreamMode.Read))
                    {
                        using(var sr = new StreamReader(cryptoStream))
                        {
                            text = sr.ReadToEnd();
                        }
                    }
                }
            }

            return text;
        }

        public static void Put(string fileName, string text)
        {
            using (var writer = new StreamWriter(fileName, true, Encoding.UTF8))
            {
                writer.WriteLine(text);
            }
        }

        public static void Delete(string fileName)
        {
            File.Delete(fileName);
        }
    }
}
