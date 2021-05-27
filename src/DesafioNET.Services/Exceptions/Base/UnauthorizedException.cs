using System;

namespace DesafioNET.Services.Exceptions.Base
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(string msg) : base(msg)
        {

        }
    }
}