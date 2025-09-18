using Shop.Application.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Security
{
    public class PasswordHelper : IPasswordHelper
    {
        public string GenerateSalt() => BCrypt.Net.BCrypt.GenerateSalt();

        public string HashPassword(string password, string salt) => BCrypt.Net.BCrypt.HashPassword(password, salt);

        public bool VerifyPassword(string password, string hashedPass) => BCrypt.Net.BCrypt.Verify(password, hashedPass);
    }
}
