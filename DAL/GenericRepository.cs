using DAL.Managers;
using Microsoft.Extensions.Configuration;
using MyMarket.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using MyMarket.Models;
using static DAL.Enum;

namespace BAL.Services
{
    public class GenericRepository<T> : ICrudOperation<T> where T : class
    {
        private readonly _DbManager<T> _dbManager;

        public GenericRepository()
        {
            _dbManager = new _DbManager<T>();
        }

        public EnumResult Add(string sql)
        {
            return _dbManager.ExecuteMethod(sql);
        }

        public int AddHeader(string sql)
        {
            return _dbManager.ExecuteTransaction(sql);
        }

        //public int AddHeader(string sql)
        //{
        //    EnumResult result = _dbManager.ExecuteTransaction(sql);
        //    _dbManager.GetById(sql); // get the id of the OperationId (PK)
        //    return result;
        //}

        //public EnumResult AddDetail(string sql)
        //{
        //    return _dbManager.ExecuteTransaction(sql);
        //}

        public EnumResult Delete(string sql)
        {
            return _dbManager.ExecuteMethod(sql);
        }

        public IEnumerable<T> GetAll(string sql)
        {
            return _dbManager.GetAll(sql);
        }

        public T GetUser(string sql)
        {
            return _dbManager.GetSingle(sql);
        }

        public EnumResult Update(string sql)
        {
            return _dbManager.ExecuteMethod(sql);
        }
    }
}
