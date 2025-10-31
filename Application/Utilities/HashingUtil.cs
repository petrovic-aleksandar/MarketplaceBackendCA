using System.Security.Cryptography;

namespace Marketplace.Application.Utilities
{
    internal sealed class HashingUtil
    {
        private const int SaltSize = 16; // 128 bit
        private const int HashSize = 32; // 256 bit
        private const int Iterations = 10000;

        private static readonly HashAlgorithmName HashAlgorithm = HashAlgorithmName.SHA256;

        public static string HashPassword(string password, string saltstr)
        {
            using var rng = RandomNumberGenerator.Create();
            byte[] salt = Convert.FromBase64String(saltstr);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithm, HashSize);
            byte[] hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);
            return Convert.ToBase64String(hashBytes);
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            byte[] hashBytes = Convert.FromBase64String(hashedPassword);
            byte[] salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);
            byte[] hash = new byte[HashSize];
            Array.Copy(hashBytes, SaltSize, hash, 0, HashSize);
            byte[] hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithm, HashSize);
            return CryptographicOperations.FixedTimeEquals(hash, hashToCompare);
        }

        public static string GenerateSalt()
        {
            using var rng = RandomNumberGenerator.Create();
            byte[] salt = new byte[SaltSize];
            rng.GetBytes(salt);
            return Convert.ToBase64String(salt);
        }
    }
}
