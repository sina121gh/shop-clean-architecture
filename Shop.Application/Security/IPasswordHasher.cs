using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Security
{
    public interface IPasswordHasher
    {
        string GenerateSalt();

        string HashPassword(string password, string salt);

        bool VerifyPassword(string password, string hashedPass);
    }
}
