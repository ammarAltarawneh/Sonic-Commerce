using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public interface IUser
    {
        public int UserId { get; set; }
        public string? Role { get; set; }
        public string? UserName { get; set; }
        public string? Passwordd { get; set; }
        public string? Token { get; set; }
    }
}
