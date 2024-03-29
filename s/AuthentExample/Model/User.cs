﻿using Microsoft.AspNetCore.Identity;

namespace AuthentExample.Model
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string? email { get; set; }
        public bool? email_confirmed { get; set; }
        public string? confirmation_code { get; set; }
    }
}
