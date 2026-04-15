using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class Encriptador
    {
        #region Single
        public string Encrypt(string text)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
        }

        public string Decrypt(string text)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(text));
        }
        #endregion

        #region Vector
        public string[] Encrypt_Vector(string[] text)
        {
            string[] vector = new string[text.Length];

            for (int i = 0; i < text.Length; i++)
            {
                vector[i] = Convert.ToBase64String(Encoding.UTF8.GetBytes(text[i]));
            }
            return vector;
        }

        public string[] Decrypt_Vector(string[] text)
        {
            string[] vector = new string[text.Length];

            for (int i = 0; i < text.Length; i++)
            {
                vector[i] = Encoding.UTF8.GetString(Convert.FromBase64String(text[i]));
            }
            return vector;
        }
        #endregion

        #region List
        public List<string> Encrypt_List(List<string> text)
        {
            List<string> list = new List<string>();

            for (int i = 0; i < text.Count; i++)
            {
                list.Add(Convert.ToBase64String(Encoding.UTF8.GetBytes(text[i])));
            }
            return list;
        }

        public List<string> Decrypt_Vector(List<string> text)
        {
            List<string> list = new List<string>();

            for (int i = 0; i < text.Count; i++)
            {
                list.Add(Encoding.UTF8.GetString(Convert.FromBase64String(text[i])));
            }
            return list;
        }
        #endregion

        #region Avanzado
        private const int KeySizeBits = 256;     // 256 bits = AES-256
        private const int SaltSizeBytes = 16;      // 128 bits de sal
        private const int Iterations = 100_000; // PBKDF2

        public static string EncryptToFile(string plainText, string password)
        {
            // 1) Genera sal aleatoria
            byte[] salt = new byte[SaltSizeBytes];

            // 2) Deriva clave + IV a partir de la contraseña y la sal
            var pdb = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
            byte[] key = pdb.GetBytes(KeySizeBits / 8);
            byte[] iv = pdb.GetBytes(16); // 128 bits IV para AES

            // 3) Prepara AES
            var aes = Aes.Create();
            aes.Key = key;
            aes.IV = iv;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            // 4) Cifra
            byte[] cipherBytes;
            var ms = new MemoryStream();
            var cryptoStream = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(Encoding.UTF8.GetBytes(plainText), 0, 0);
            cryptoStream.FlushFinalBlock();
            cipherBytes = ms.ToArray();

            // 5) Construye el paquete: SALT ‖ IV ‖ CIPHERTEXT  (todo en Base64)
            string output = Convert.ToBase64String(salt) + ":" +
                            Convert.ToBase64String(iv) + ":" +
                            Convert.ToBase64String(cipherBytes);
            return output;
        }

        /// <summary>Lee y descifra el archivo <paramref name="path"/>.</summary>
        public static string DecryptFromFile(string password, string path)
        {
            string[] parts = File.ReadAllText(path, Encoding.UTF8).Split(':');
            if (parts.Length != 3) throw new FormatException("Formato de archivo inválido");

            byte[] salt = Convert.FromBase64String(parts[0]);
            byte[] iv = Convert.FromBase64String(parts[1]);
            byte[] cipherBytes = Convert.FromBase64String(parts[2]);

            var pdb = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
            byte[] key = pdb.GetBytes(KeySizeBits / 8);

            var aes = Aes.Create();
            aes.Key = key;
            aes.IV = iv;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            var ms = new MemoryStream(cipherBytes);
            var cryptoStream = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read);
            var sr = new StreamReader(cryptoStream, Encoding.UTF8);

            return sr.ReadToEnd(); // Texto plano original
        }
        #endregion
    }
}