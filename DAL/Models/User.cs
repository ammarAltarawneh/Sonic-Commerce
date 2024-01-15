using MyMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    internal class User
    {
        public int UserId { get; set; }
        public int Role { get; set; }
        public string? UserName { get; set; }
        public string? Passwordd { get; set; }
    }
}
