using BAL.Services;
using DAL;
using DAL.Managers;
using DAL.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Models;
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
    private readonly IUser _user;
    public CategoryService(IUser user)
    {
        _user = user;
        _categoryManager = new CategoryManager(user);
    }

        public IEnumerable<Category> GetAll()
        {
            return _categoryManager.GetAll();
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

    }
}
