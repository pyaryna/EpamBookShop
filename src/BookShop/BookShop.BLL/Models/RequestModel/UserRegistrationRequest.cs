﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.BLL.Models.RequestModel
{
    public class UserRegistrationRequest
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
