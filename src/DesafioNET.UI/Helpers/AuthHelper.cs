using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioNET.Services;

namespace DesafioNET.UI.Helpers
{
    public static class AuthHelper
    {
        public static Guid GetId(this System.Security.Principal.IIdentity identity)
        {
            return Guid.Parse(identity.Name);
        }

        //public static string GetName(this System.Security.Principal.IIdentity identity)
        //{
        //    return identity
        //}
    }
}
