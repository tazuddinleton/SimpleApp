using System;
using System.Security.Cryptography;
using System.Text;

namespace SimpleApp.Infrastructure
{
    public static class Extensions
    {
        public static string ToSHA256(this string input)
        {
            using (var sha = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(input);
                var hash = sha.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
