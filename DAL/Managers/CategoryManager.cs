using BAL.Services;
using DAL.Models;
using Models;
using MyMarket.Models;
using static DAL.Enum;

namespace DAL.Managers
{
    public class CategoryManager
    {
        private readonly GenericRepository<Category> _genericRepository;
        private readonly IUser _user;
        public CategoryManager(IUser user)
        {
            _genericRepository = new GenericRepository<Category>();
            _user = user;
        }

        public IEnumerable<Category> GetAll()
        {
  
            string sql = $"SELECT * FROM Category WHERE UserId = {_user.UserId}";
            return _genericRepository.GetAll(sql);
        }

        public EnumResult Add(Category category)
        {
            string sql = $"INSERT INTO Category (CategoryName,UserId) VALUES ('{category.CategoryName}',{category.UserId})";
            return _genericRepository.Add(sql);
        }

        public EnumResult Update(Category category)
        {
            string sql = $"UPDATE Category SET CategoryName = '{category.CategoryName}', UserId = {category.UserId} WHERE CategoryId = {category.CategoryId}";
            return _genericRepository.Update(sql);
        }

        public EnumResult Delete(int id)
        {
            string sql = $"DELETE FROM Category WHERE CategoryId = {id}";
            return _genericRepository.Delete(sql);
        }
    }
}
