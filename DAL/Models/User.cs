﻿using Models;
using MyMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class User : IUser
    {
        public int UserId { get; set; }
        public string? Role { get; set; }
        public string? UserName { get; set; }
        public string? Passwordd { get; set; }
        public string? Token { get; set; }
    }
}
