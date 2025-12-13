using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace N9.Helpers
{
    public static class CryptoHelper
    {
        public static string GenerateSalt()
        {
            byte[] saltBytes = new byte[32];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        public static string HashPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var combined = password + salt;
                var bytes = Encoding.UTF8.GetBytes(combined);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        public static bool VerifyPassword(string password, string salt, string storedHash)
        {
            var hash = HashPassword(password, salt);
            return hash == storedHash;
        }

        // AES Encryption for backup files
        public static byte[] Encrypt(byte[] data, string password)
        {
            using (var aes = Aes.Create())
            {
                var key = DeriveKey(password, 32);
                var iv = DeriveKey(password + "IV", 16);
                
                aes.Key = key;
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (var encryptor = aes.CreateEncryptor())
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        cs.Write(data, 0, data.Length);
                    }
                    return ms.ToArray();
                }
            }
        }

        public static byte[] Decrypt(byte[] encryptedData, string password)
        {
            using (var aes = Aes.Create())
            {
                var key = DeriveKey(password, 32);
                var iv = DeriveKey(password + "IV", 16);
                
                aes.Key = key;
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (var decryptor = aes.CreateDecryptor())
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write))
                    {
                        cs.Write(encryptedData, 0, encryptedData.Length);
                    }
                    return ms.ToArray();
                }
            }
        }

        private static byte[] DeriveKey(string password, int keySize)
        {
            using (var sha256 = SHA256.Create())
            {
                var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var key = new byte[keySize];
                Array.Copy(hash, key, Math.Min(hash.Length, keySize));
                return key;
            }
        }

        // For Remember Me feature - encrypt/decrypt username
        public static string EncryptString(string plainText, string key)
        {
            if (string.IsNullOrEmpty(plainText)) return "";
            var data = Encoding.UTF8.GetBytes(plainText);
            var encrypted = Encrypt(data, key);
            return Convert.ToBase64String(encrypted);
        }

        public static string DecryptString(string encryptedText, string key)
        {
            if (string.IsNullOrEmpty(encryptedText)) return "";
            try
            {
                var data = Convert.FromBase64String(encryptedText);
                var decrypted = Decrypt(data, key);
                return Encoding.UTF8.GetString(decrypted);
            }
            catch
            {
                return "";
            }
        }
    }
}
