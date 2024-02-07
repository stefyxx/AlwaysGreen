﻿using AlwaysGreen.Domain.Entities;
using AlwaysGreen.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace AlwaysGreen.DTO
{
    public class RegisteredParticularDTO
    {
        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public AddressCreateDTO Address { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [RegexStringValidator("^[a-zA-Z][a-zA-Z0-9]{3,9}$")]  //Non iniziano con cifre + min/max length restrictions (min 4 and max 10) 
        public string Username { get;set; }
    }
}