using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public sealed class Encriptador_44MM
    {
        private static readonly object _candado = new object();

        private Encriptador_44MM() { }

        private static Encriptador_44MM _Instancia;

        public static Encriptador_44MM Instancia
        {
            get
            {
                if (_Instancia == null)
                {
                    lock (_candado)
                    {
                        if (_Instancia == null)
                        {
                            _Instancia = new Encriptador_44MM();
                        }
                    }
                }
                return _Instancia;
            }
        }

        public static string Computar(string texto)
        {
            /*using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(texto);
                byte[] hash = sha256.ComputeHash(bytes);

                // Convertir a string hexadecimal
                StringBuilder result = new StringBuilder();
                foreach (byte b in hash)
                {
                    result.Append(b.ToString("x2")); // formato hex
                }

                return result.ToString();
            }*/
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(texto));
        }

        private const int KeySize = 256;     // AES-256
        private const int BlockSize = 128;   // Tamaño de bloque
        private const int SaltSize = 16;     // 128 bits
        private const int Iterations = 100000;

        public static string Encriptar(string texto, string contra)
        {
            byte[] salt = new byte[SaltSize];

            var keyDerivation = new Rfc2898DeriveBytes(contra, salt, Iterations, HashAlgorithmName.SHA256);
            byte[] key = keyDerivation.GetBytes(KeySize / 8);

            var aes = Aes.Create();
            aes.KeySize = KeySize;
            aes.BlockSize = BlockSize;
            aes.Key = key;
            aes.GenerateIV();

            var encryptor = aes.CreateEncryptor();
            var ms = new MemoryStream();

            // Guardamos: SALT + IV + DATA
            ms.Write(salt, 0, salt.Length);
            ms.Write(aes.IV, 0, aes.IV.Length);

            using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
            using (var sw = new StreamWriter(cs))
            {
                sw.Write(texto);
            }

            return Convert.ToBase64String(ms.ToArray());
        }

        public static string Desencriptar(string texto, string contra)
        {
            byte[] fullData = Convert.FromBase64String(texto);

            byte[] salt = new byte[SaltSize];
            byte[] iv = new byte[16];

            Array.Copy(fullData, 0, salt, 0, salt.Length);
            Array.Copy(fullData, salt.Length, iv, 0, iv.Length);

            byte[] cipher = new byte[fullData.Length - salt.Length - iv.Length];
            Array.Copy(fullData, salt.Length + iv.Length, cipher, 0, cipher.Length);

            var keyDerivation = new Rfc2898DeriveBytes(contra, salt, Iterations, HashAlgorithmName.SHA256);
            byte[] key = keyDerivation.GetBytes(KeySize / 8);

            var aes = Aes.Create();
            aes.KeySize = KeySize;
            aes.BlockSize = BlockSize;
            aes.Key = key;
            aes.IV = iv;

            var decryptor = aes.CreateDecryptor();
            var ms = new MemoryStream(cipher);
            var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            var sr = new StreamReader(cs);

            return sr.ReadToEnd();
        }
    }
}