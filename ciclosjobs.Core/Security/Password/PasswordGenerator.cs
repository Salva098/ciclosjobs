using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace ciclosjobs.Core.Security
{
    public class PasswordGenerator : IPasswordGenerator
    {
        public IConfiguration Configuration { get; set; }
        public PasswordGenerator(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }
        public string Hash(string password)
        {
            byte[] salt = Encoding.UTF8.GetBytes(Configuration["SecretKey"]);
 

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 98765,
                numBytesRequested: 256 / 8));
            return hashed;
        }
    }
}
