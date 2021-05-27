using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioNET.UI.Helpers
{
    public static class AuthHelper
    {
        public static Guid GetId(this System.Security.Principal.IIdentity identity)
        {
            return Guid.Parse(identity.Name);
        }
    }
}
