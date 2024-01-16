using BAL.Services;
using DAL.Models;
using MyMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers
{
    public class UserManager
    {
        private readonly GenericRepository<User> _genericRepository;

        public UserManager()
        {
            _genericRepository = new GenericRepository<User>();
        }
        public IEnumerable<User> GetAll()
        {
            string sql = "SELECT * FROM Users;";
            return _genericRepository.GetAll(sql);
        }

        public User GetUser(User user)
        {
            string sql = $"SELECT * FROM Users WHERE UserName = {user.UserName} AND Passwordd = {user.Passwordd};";
            return _genericRepository.GetUser(sql);
        }
    }
}
