using BAL.Services;
using DAL.Models;
using Models;
using System.Transactions;
using static DAL.Enum;

namespace DAL.Managers
{
    public class OperationManager
    {
        private readonly GenericRepository<Operationn> _genericRepository;
        private readonly GenericRepository<OperationDetail> _operationDetailRepository;
        private readonly GenericRepository<OperationInAngular> _operationInAngularRepo;

        public OperationManager()
        {
            _genericRepository = new GenericRepository<Operationn>();
            _operationDetailRepository = new GenericRepository<OperationDetail>();
            _operationInAngularRepo = new GenericRepository<OperationInAngular>();
        }

        public EnumResult AddTransaction(Operationn operation)
        {
            using (var transactionScope = new TransactionScope())
            {
                try
                {
                    string operationSql = $"INSERT INTO Operation (UserId, OperationTypeId, CustomerId, OperationDate, TaxTotal, DiscountTotal, GrossTotal, NetTotal) " +
                                         $"VALUES ({operation.UserId}, {operation.OperationTypeId}, {operation.CustomerId}, " +
                                         $"'{operation.OperationDate:yyyy-MM-dd HH:mm:ss}', {operation.TaxTotal}, {operation.DiscountTotal}, {operation.GrossTotal}, {operation.NetTotal}) " +
                                         $"SELECT CAST(SCOPE_IDENTITY() AS INT)";

                    int operationId =_genericRepository.AddHeader(operationSql); // execute and get OperationId for the new record

                    if (operationId > 0)
                    {
                        string detailSql = string.Empty;
                        operation.operationDetail.ToList().ForEach(
                            detail =>
                            {
                                detailSql = detailSql + $"INSERT INTO OperationDetails (OperationId, ItemId, Quantity) " +
                                                        $"VALUES ({operationId}, {detail.ItemId}, {detail.Quantity})";
                            }
                          );

                        _operationDetailRepository.Add(detailSql);

                        transactionScope.Complete();

                        return EnumResult.Success;
                    }
                    else
                    {
                        return EnumResult.Fail;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception occurred " + ex.ToString());
                    return EnumResult.Fail;
                }
            }
        }

        public IEnumerable<OperationInAngular> GetAll()
        {
            string sql = "SELECT O.OperationId, OT.OperationTypeName, C.CustomerName, O.OperationDate, O.NetTotal, O.GrossTotal " +
                          "FROM Operation AS O " +
                          "JOIN OperationType AS OT ON O.OperationTypeId = OT.OperationTypeId " +
                          "JOIN Customer AS C ON O.CustomerId = C.CustomerId " +
                          "ORDER BY O.OperationId ASC;";
            return _operationInAngularRepo.GetAll(sql);
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
