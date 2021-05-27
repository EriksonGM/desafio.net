using DesafioNET.Services.Exceptions.Base;

namespace DesafioNET.Services.Exceptions
{
    public class InvalidLoginException : UnauthorizedException
    {
        public InvalidLoginException() : base("Tentativa de login inválida")
        {
        }
    }
}