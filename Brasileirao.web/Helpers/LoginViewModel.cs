﻿using Brasileirao.web.Models;

namespace Brasileirao.web.Helpers
{
    public class LoginViewModel
    {
        public User Username { get; internal set; }
        public string Password { get; internal set; }
        public bool RememberMe { get; internal set; }
    }
}