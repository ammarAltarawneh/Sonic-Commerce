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

        public User GetById(int id)
        {
            string sql = $"SELECT * FROM Users WHERE UserId = {id};";
            return _genericRepository.GetById(sql);
        }

        public User GetUser(string username, string password)
        {
            var sql = $"SELECT * FROM Users WHERE UserName = '{username}' AND Passwordd = '{password}';"; ;
            return _genericRepository.GetById(sql);
        }
    }
}
