using DAL.Managers;
using MyMarket.Interface;
using static DAL.Enum;

namespace BAL.Services
{
    public class GenericRepository<T> : IRepository<T> where T : class
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

        public EnumResult Delete(string sql)
        {
            return _dbManager.ExecuteMethod(sql);
        }

        public IEnumerable<T> GetAll(string sql)
        {
            return _dbManager.GetAll(sql);
        }

        public T GetById(string sql)
        {
            return _dbManager.GetSingle<T>(sql);
        }

        public EnumResult Update(string sql)
        {
            return _dbManager.ExecuteMethod(sql);
        }
    }
}
