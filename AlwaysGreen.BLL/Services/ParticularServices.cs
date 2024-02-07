﻿using AlwaysGreen.BLL.Interfaces;
using AlwaysGreen.Domain.Entities;
using AlwaysGreen.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlwaysGreen.BLL.Services
{
    public class ParticularServices(IParticularRepository _particularRepository, IPasswordHasher _passwordHasher)
    {
        //getAll
        public List<Particular> GetAll()
        {
            return _particularRepository.GetAll();
        }

        public Particular Register(string FirstName, string LastName, string PhoneNumber, string Email,Address address, string password, string Username)
        {
            byte[] hash = _passwordHasher.Hash(Email + password);
            return _particularRepository.Add(new Particular 
            { 
                FirstName = FirstName,
                LastName = LastName,
                PhoneNumber = PhoneNumber,
                IsActive = true,
                Email = Email,
                Address = address,

            });
        }
    }
}