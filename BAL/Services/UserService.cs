using DAL.Managers;
using DAL.Models;
using Managers;
using MyMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService
    {
        private readonly UserManager _userManager;

        public UserService()
        {
            _userManager = new UserManager();
        }
        public IEnumerable<User> GetAll()
        {
            return _userManager.GetAll();
        }

        public User GetUser(string username, string password)
        {
            return _userManager.GetUser(username, password);
        }

    }
}
