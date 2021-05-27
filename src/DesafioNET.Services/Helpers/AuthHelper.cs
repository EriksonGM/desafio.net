using System;
using System.Linq;
using System.Security.Claims;

namespace DesafioNET.Services.Helpers
{
    public static class AuthHelper
    {
        public static Guid GetId(this ClaimsPrincipal user)
        {
            var value = user.Identities
                .SelectMany(x => x.Claims)
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)
                ?.Value;

            if (string.IsNullOrEmpty(value))
                return Guid.Empty;

            return Guid.Parse(value);
        }

        public static bool HasPermition(this ClaimsPrincipal user, int permition)
        {
            var value = user.Identities
                .SelectMany(x => x.Claims)
                .Any(x => x.Type == ClaimTypes.Authentication && x.Value == permition.ToString());

            return value;
        }

    }
}