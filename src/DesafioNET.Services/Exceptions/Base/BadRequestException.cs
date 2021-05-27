using System;

namespace DesafioNET.Services.Exceptions.Base
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string msg) : base(msg)
        {

        }
    }
}