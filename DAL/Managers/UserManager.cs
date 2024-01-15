//using BAL.Services;
//using DAL.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using static DAL.Enum;

//namespace Managers
//{
//    public class UserManager
//    {
//        private readonly GenericRepository<User> _genericRepository;

//        public UserManager()
//        {
//            _genericRepository = new GenericRepository<User>();
//        }

//        public EnumResult AddTransaction(User user)
//        {
//            var result = EnumResult.Fail;
//            string sql_1 = $"INSERT INTO Users (UserId,Username, Passwordd, Role_) " +
//                         $"VALUES ({user.UserId}, '{user.UserName}', {user.Passwordd}, " +
//                         $"{user.Role})";

//            foreach (var categories in user.categories)
//            {
//                string sql_2 = $"INSERT INTO Category (OperationId, ItemId, Quantity ) " +
//                             $"VALUES ({categories.CategoryId}, {categories.CategoryId}, {categories.UserId})";

//                result = _genericRepository.AddTransaction(sql_1, sql_2);
//            }

//            return result;
//        }

//        public EnumResult AddDeatail(Operationn operation)
//        {
//            var result = EnumResult.Fail;
//            foreach (var opDetail in operation.operationDetail)
//            {
//                string sql = $"INSERT INTO OperationDetail (OperationId, ItemId, Quantity ) " +
//                             $"VALUES ({opDetail.OperationId}, {opDetail.ItemId}, {opDetail.Quantity})";

//                result = _genericRepository.Add(sql);
//            }
//            return result;
//        }

//        public IEnumerable<Operationn> GetAll()
//        {
//            string sql = "SELECT * FROM Operation";
//            return _genericRepository.GetAll(sql);
//        }

//        public EnumResult Update(Operationn operation)
//        {
//            string sql = $"UPDATE Operation SET UserId = {operation.UserId}, OperationTypeId = {operation.OperationTypeId}, " +
//                         $"CustomerId = {operation.CustomerId}, OperationDate = '{operation.OperationDate:yyyy-MM-dd HH:mm:ss}', " +
//                         $"TaxTotal = {operation.TaxTotal}, DiscountTotal = {operation.DiscountTotal}, " +
//                         $"GrossTotal = {operation.GrossTotal}, NetTotal = {operation.NetTotal} " +
//                         $"WHERE OperationId = {operation.OperationId}";

//            return _genericRepository.Update(sql);
//        }

//        public EnumResult Delete(int id)
//        {
//            string sql = $"DELETE FROM Operation WHERE OperationId = {id}";
//            return _genericRepository.Delete(sql);
//        }
//    }
//}
