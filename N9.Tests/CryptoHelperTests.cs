using Microsoft.VisualStudio.TestTools.UnitTesting;
using N9.Helpers;

namespace N9.Tests
{
    [TestClass]
    public class CryptoHelperTests
    {
        [TestMethod]
        public void GenerateSalt_ShouldReturnNonEmptyString()
        {
            var salt = CryptoHelper.GenerateSalt();
            Assert.IsFalse(string.IsNullOrEmpty(salt));
        }

        [TestMethod]
        public void GenerateSalt_ShouldReturnDifferentValuesEachTime()
        {
            var salt1 = CryptoHelper.GenerateSalt();
            var salt2 = CryptoHelper.GenerateSalt();
            Assert.AreNotEqual(salt1, salt2);
        }

        [TestMethod]
        public void HashPassword_ShouldReturnConsistentHash()
        {
            var password = "TestPassword123";
            var salt = "TestSalt";
            
            var hash1 = CryptoHelper.HashPassword(password, salt);
            var hash2 = CryptoHelper.HashPassword(password, salt);
            
            Assert.AreEqual(hash1, hash2);
        }

        [TestMethod]
        public void HashPassword_DifferentSaltsShouldProduceDifferentHashes()
        {
            var password = "TestPassword123";
            var salt1 = "Salt1";
            var salt2 = "Salt2";
            
            var hash1 = CryptoHelper.HashPassword(password, salt1);
            var hash2 = CryptoHelper.HashPassword(password, salt2);
            
            Assert.AreNotEqual(hash1, hash2);
        }

        [TestMethod]
        public void VerifyPassword_ShouldReturnTrueForCorrectPassword()
        {
            var password = "TestPassword123";
            var salt = CryptoHelper.GenerateSalt();
            var hash = CryptoHelper.HashPassword(password, salt);
            
            var result = CryptoHelper.VerifyPassword(password, salt, hash);
            
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void VerifyPassword_ShouldReturnFalseForIncorrectPassword()
        {
            var password = "TestPassword123";
            var wrongPassword = "WrongPassword";
            var salt = CryptoHelper.GenerateSalt();
            var hash = CryptoHelper.HashPassword(password, salt);
            
            var result = CryptoHelper.VerifyPassword(wrongPassword, salt, hash);
            
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void EncryptDecryptString_ShouldReturnOriginalValue()
        {
            var original = "TestString123";
            var key = "SecretKey";
            
            var encrypted = CryptoHelper.EncryptString(original, key);
            var decrypted = CryptoHelper.DecryptString(encrypted, key);
            
            Assert.AreEqual(original, decrypted);
        }

        [TestMethod]
        public void EncryptString_ShouldReturnDifferentValueThanOriginal()
        {
            var original = "TestString123";
            var key = "SecretKey";
            
            var encrypted = CryptoHelper.EncryptString(original, key);
            
            Assert.AreNotEqual(original, encrypted);
        }

        [TestMethod]
        public void DecryptString_WithWrongKey_ShouldReturnEmptyString()
        {
            var original = "TestString123";
            var key = "SecretKey";
            var wrongKey = "WrongKey";
            
            var encrypted = CryptoHelper.EncryptString(original, key);
            var decrypted = CryptoHelper.DecryptString(encrypted, wrongKey);
            
            Assert.AreNotEqual(original, decrypted);
        }
    }
}
