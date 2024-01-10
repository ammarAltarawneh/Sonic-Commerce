using BAL.Services;
using DAL.Managers;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MyMarket.Interface;
using MyMarket.Models;
using System.Data;
using System.Data.Common;
using static DAL.Enum;

namespace MyMarket.Services
{
    public class CategoryService 
    {
        private readonly CategoryManager _categoryManager;

        public CategoryService()
        {
            _categoryManager = new CategoryManager();
        }

        public EnumResult Add(Category category)
        {
            try
            {
                return _categoryManager.Add(category);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception occured " + ex.ToString());
                return EnumResult.Fail;
            }            
        }
        public EnumResult Update(Category category)
        {
            try
            {
                return _categoryManager.Update(category);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occured " + ex.ToString());
                return EnumResult.Fail;
            }
        }

        public EnumResult Delete(int id)
        {
            try
            {
                return _categoryManager.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occured " + ex.ToString());
                return EnumResult.Fail;
            }
        }

        public IEnumerable<Category> GetAll()
        {
             return _categoryManager.GetAll();
        }

    }
}
