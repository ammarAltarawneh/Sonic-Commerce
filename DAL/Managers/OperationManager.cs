using Azure;
using BAL.Services;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DAL.Enum;

namespace DAL.Managers
{
    public class OperationManager
    {
        private readonly GenericRepository<Operationn> _genericRepository;

        public OperationManager()
        {
            _genericRepository = new GenericRepository<Operationn>();
        }

        public EnumResult Add(Operationn operation)
        {
            string sql = $"INSERT INTO Operation (UserId, OperationTypeId, CustomerId, OperationDate, TaxTotal, DiscountTotal, GrossTotal, NetTotal) " +
                         $"VALUES ({operation.UserId}, {operation.OperationTypeId}, {operation.CustomerId}, " +
                         $"'{operation.OperationDate:yyyy-MM-dd HH:mm:ss}', {operation.TaxTotal}, {operation.DiscountTotal}, {operation.GrossTotal}, {operation.NetTotal})";

            return _genericRepository.Add(sql);
        }

        public IEnumerable<Operationn> GetAll()
        {
            string sql = "SELECT * FROM Operation";
            return _genericRepository.GetAll(sql);
        }

        public EnumResult Update(Operationn operation)
        {
            string sql = $"UPDATE Operation SET UserId = {operation.UserId}, OperationTypeId = {operation.OperationTypeId}, " +
                         $"CustomerId = {operation.CustomerId}, OperationDate = '{operation.OperationDate:yyyy-MM-dd HH:mm:ss}', " +
                         $"TaxTotal = {operation.TaxTotal}, DiscountTotal = {operation.DiscountTotal}, " +
                         $"GrossTotal = {operation.GrossTotal}, NetTotal = {operation.NetTotal} " +
                         $"WHERE OperationId = {operation.OperationId}";

            return _genericRepository.Update(sql);
        }

        public EnumResult Delete(int id)
        {
            string sql = $"DELETE FROM Operation WHERE OperationId = {id}";
            return _genericRepository.Delete(sql);
        }
    }

}
