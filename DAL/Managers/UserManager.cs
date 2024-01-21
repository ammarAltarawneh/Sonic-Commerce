using BAL.Services;
using DAL.Models;

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

        public User GetUser(string username, string password)
        {
            var sql = $"SELECT * FROM Users WHERE UserName = '{username}' AND Passwordd = '{password}';"; ;
            return _genericRepository.GetById(sql);
        }
    }
}
