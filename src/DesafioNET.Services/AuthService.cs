using System;
using System.Linq;
using System.Threading.Tasks;
using DesafioNET.Data;
using DesafioNET.Data.Entites;
using DesafioNET.Services.Exceptions;
using DesafioNET.Services.Helpers;
using DesafioNET.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioNET.Services
{
    public interface IAuthService : IService
    {
        Task<UserDTO> TryLoginAsync(string email, string pass);

        UserDTO Register(string name, string email, string pass);
    }

    public class AuthService : Service, IAuthService
    {
        public AuthService(DataContext db) : base(db)
        {

        }

        public async Task<UserDTO> TryLoginAsync(string email, string pass)
        {
            var hashedPass = pass.ToSHA512();

            var user = await _db.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password == hashedPass);

            return user != null ? new UserDTO(user) : null;
        }

        public UserDTO Register(string name, string email, string pass)
        {
            if (_db.Users.Any(x => x.Email == email))
            {
                throw new EmailAlreadyExistException();
            }

            var user = new User
            {
                UserId = Guid.NewGuid(),
                Name = name,
                Email = email.ToLower(),
                Password = pass.ToSHA512()
            };

            _db.Users.Add(user);

            return new UserDTO(user);
        }

    }
}