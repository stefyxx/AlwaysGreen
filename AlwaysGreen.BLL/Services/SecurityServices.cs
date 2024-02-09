using AlwaysGreen.BLL.Interfaces;
using AlwaysGreen.Domain.Entities;
using AlwaysGreen.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlwaysGreen.BLL.Services
{
    public class SecurityServices(ILoginRepository _loginRepository, IPasswordHasher _passwordHasher)
    {
        public Login Login(string username, string password)
        {
            Login? l = _loginRepository.Get(username);

            if (l == null) throw new ValidationException("Aucun user avec cet username");

            string email;
            if (l.Roles.Contains(RolesEnum.Particular)) email = l.Particular.Email;
            else email = l.Depot.Email;

            if (!_passwordHasher.Hash(email + password).SequenceEqual(l.Password)) throw new ValidationException("pwd non valide");
            
            return l;

            //if (l.Roles.Contains(RolesEnum.Particular))
            //{
            //    Particular? p = _loginRepository.GetParticular(username);
            //    if (p == null) throw new ValidationException("Aucun user avec cet email");
            //    if (!_passwordHasher.Hash(p.Email + password).SequenceEqual(l.Password)) throw new ValidationException("pwd non valide");
            //    //return l;
            //    return p;
            //}
            //else
            //{
            //    //company or store or depot
            //    Location loc = _loginRepository.GetLocation(username);
            //    if (!_passwordHasher.Hash(loc.Email + password).SequenceEqual(l.Password)) throw new ValidationException("pwd non valide");
            //    return l;
            //}


        }

    }
}
