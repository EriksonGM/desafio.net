using System;

namespace DesafioNET.Services.Exceptions.Base
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string msg) : base(msg)
        {

        }
    }
}