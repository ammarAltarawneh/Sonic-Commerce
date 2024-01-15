using BAL.Services;
using MyMarket.Interface;
using MyMarket.Models;
using static DAL.Enum;

namespace DAL.Managers
{
    public class CategoryManager
    {
        private readonly GenericRepository<Category> _genericRepository;

        public CategoryManager()
        {
            _genericRepository = new GenericRepository<Category>();
        }

      
        public EnumResult Add(Category category)
        {
            string sql = $"INSERT INTO Category (CategoryName,UserId) VALUES ('{category.CategoryName}',{category.UserId})";
            return _genericRepository.Add(sql);
        }

        public IEnumerable<Category> GetAll()
        {
            string sql = "SELECT * FROM Category";
            return _genericRepository.GetAll(sql);
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
