using BAL.Services;
using DAL.Models;
using MyMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DAL.Enum;

namespace DAL.Managers
{
    public class ItemManager
    {
        private readonly GenericRepository<Item> _genericRepository;
        public ItemManager()
        {
            _genericRepository = new GenericRepository<Item>();
        }

        public EnumResult Add(Item item)
        {
            string sql = $"INSERT INTO Item (CategoryId,ItemName,Price,Discount,Tax) VALUES ({item.CategoryId},'{item.ItemName}',{item.Price},{item.Discount},{item.Tax})";
            return _genericRepository.Add(sql);
        }

        public IEnumerable<Item> GetAll()
        {
            string sql = "SELECT * FROM Item";
            return _genericRepository.GetAll(sql);
        }

        public EnumResult Update(Item item)
        {
            string sql = $"UPDATE Item SET CategoryId = {item.CategoryId}, ItemName = '{item.ItemName}', Price = {item.Price}, Discount = {item.Discount}, Tax = {item.Tax} WHERE ItemId = {item.ItemId}";
            return _genericRepository.Update(sql);
        }

        public EnumResult Delete(int id)
        {
            string sql = $"DELETE FROM Item WHERE ItemId = {id}";
            return _genericRepository.Delete(sql);
        }
    }
}
