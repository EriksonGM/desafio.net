using DesafioNET.Services.Exceptions.Base;

namespace DesafioNET.Services.Exceptions
{
    public class EmailAlreadyExistException : BadRequestException
    {
        public EmailAlreadyExistException() : base("Já existe uma conta registada com este email.")
        {
        }
    }
}