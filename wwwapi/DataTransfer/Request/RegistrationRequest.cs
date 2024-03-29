﻿using System.ComponentModel.DataAnnotations;
using wwwapi.Enums;

namespace wwwapi.DataTransfer.Request
{
    public class RegistrationRequest
    {
        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Username { get { return this.Email; } set { } }

        [Required]
        public string? Password { get; set; }

        public Role Role { get; set; } = Role.User;
    }
}

