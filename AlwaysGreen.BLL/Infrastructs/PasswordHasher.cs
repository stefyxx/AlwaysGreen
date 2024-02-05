using AlwaysGreen.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AlwaysGreen.BLL.Infrastructs
{
    public class PasswordHasher : IPasswordHasher
    {
        public byte[] Hash(string password)
        {
            return SHA512.HashData(Encoding.UTF8.GetBytes(password));
        }

        //Random psw allla registrazione di particular or location
        public string CreateRandomPassword(int lenght)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+";
            var random = new Random();
            string password = new string(Enumerable.Repeat(chars, lenght)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            return password;
        }

    }
}
