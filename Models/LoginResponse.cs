﻿using PvDriver.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PvDriver.Models
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public User User { get; set; }
    }
}
