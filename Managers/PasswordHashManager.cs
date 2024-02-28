// Generated via GPT 3.5 turbo [not verified]

using System.Security.Cryptography;

namespace ApiProject.Managers
{
    public class PasswordHasher
    {
        // Generate a salt
        private static byte[] GenerateSalt(int saltSize = 16)
        {
            byte[] salt = new byte[saltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        // Hash a password using PBKDF2 with HMAC-SHA256
        public static string HashPassword(string password, int iterations = 10000, int saltSize = 16, int hashSize = 32)
        {
            byte[] salt = GenerateSalt(saltSize);

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256))
            {
                byte[] hash = pbkdf2.GetBytes(hashSize);
                byte[] hashBytes = new byte[saltSize + hashSize];
                Array.Copy(salt, 0, hashBytes, 0, saltSize);
                Array.Copy(hash, 0, hashBytes, saltSize, hashSize);
                return Convert.ToBase64String(hashBytes);
            }
        }

        // Verify a password against a hashed password
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            byte[] hashBytes = Convert.FromBase64String(hashedPassword);
            int saltSize = 16;
            byte[] salt = new byte[saltSize];
            Array.Copy(hashBytes, 0, salt, 0, saltSize);

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256))
            {
                byte[] hash = pbkdf2.GetBytes(32);
                for (int i = 0; i < 32; i++)
                {
                    if (hashBytes[i + saltSize] != hash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }

}