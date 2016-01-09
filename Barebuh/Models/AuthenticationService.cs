using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Barebuh.Models
{
    public interface IAuthenticationService
    {
        User AuthenticateUser(string username, string password);
    }
    public class AuthenticationService : IAuthenticationService
    {
        private class InternalUserData
        {
            public InternalUserData(string username, string email, string hashedPassword, string[] roles)
            {
                Username = username;
                Email = email;
                HashedPassword = hashedPassword;
                Roles = roles;
            }
            public string Username { get; private set; }
            public string Email { get; private set; }
            public string HashedPassword { get; private set; }
            public string[] Roles { get; private set; }
        }

        private static readonly List<InternalUserData> _users = new List<InternalUserData>()
        {
            new InternalUserData("admin", "weww", "gqefEbSstSpkLvfjOd/OSqkv9l7S56twLXmNvhDsoLg=", new string[] {"Administrators"}),
            new InternalUserData("user", "sdfdv", "Gwuwwbjy8jshz6B/0eIezh1esYHs6Yi4JKaKk/OtHn0=", new string[] {"Loh"})
        }; 



        public User AuthenticateUser(string username, string clearTextPassword)
        {
            InternalUserData userData = _users.FirstOrDefault(u =>
                u.Username.Equals(username) &&
                u.HashedPassword.Equals(CalculateHash(clearTextPassword, u.Username)));
            if(userData == null)
                throw new UnauthorizedAccessException("Доступ закрыт.");

            return new User(userData.Username,userData.Email, userData.Roles);
        }

        private string CalculateHash(string clearTextPassword, string salt)
        {
            byte[] saltedHashBytes = Encoding.UTF8.GetBytes(clearTextPassword + salt);
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] hash = algorithm.ComputeHash(saltedHashBytes);
            var s = Convert.ToBase64String(hash);
            return Convert.ToBase64String(hash);
        }
    }



    public class User
    {
        public User(string username, string email, string[] roles)
        {
            Username = username;
            Email = email;
            Roles = roles;
        }

        public string Username { get; set; }
        public string Email { get; set; }
        public string[] Roles { get; set; }
    }
}
