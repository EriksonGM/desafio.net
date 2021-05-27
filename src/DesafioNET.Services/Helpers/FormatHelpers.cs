using System.Security.Cryptography;
using System.Text;

namespace DesafioNET.Services.Helpers
{
    public static class FormatHelpers
    {
        public static string ToSHA512(this string text)
        {
            using SHA512 sha512Hash = SHA512.Create();

            var bytes = sha512Hash.ComputeHash(Encoding.UTF8.GetBytes(text));

            var builder = new StringBuilder();

            foreach (var t in bytes)
            {
                builder.Append(t.ToString("x2"));
            }

            return builder.ToString();
        }
    }
}