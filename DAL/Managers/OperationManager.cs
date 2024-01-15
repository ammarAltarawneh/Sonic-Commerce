﻿using Azure;
using BAL.Services;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static DAL.Enum;

namespace DAL.Managers
{
    public class OperationManager
    {
        private readonly GenericRepository<Operationn> _genericRepository;
        private readonly GenericRepository<OperationDetail> _operationDetailRepository;

        public OperationManager()
        {
            _genericRepository = new GenericRepository<Operationn>();
            _operationDetailRepository = new GenericRepository<OperationDetail>();
        }

        //public EnumResult AddTransactionHeader(int id,Operationn operation)
        //{
        //    string sql = $"INSERT INTO Operation (UserId, OperationTypeId, CustomerId, OperationDate, TaxTotal, DiscountTotal, GrossTotal, NetTotal) " +
        //                 $"VALUES ({operation.UserId}, {operation.OperationTypeId}, {operation.CustomerId}, " +
        //                 $"'{operation.OperationDate:yyyy-MM-dd HH:mm:ss}', {operation.TaxTotal}, {operation.DiscountTotal}, {operation.GrossTotal}, {operation.NetTotal}) " +
        //                 $"SELECT CAST(SCOPE_IDENTITY() AS INT)";

        //   return _genericRepository.AddHeader(ref id,sql);
        //}



        //public EnumResult AddTransactionDetail(Operationn operation)
        //{
        //     string sql = $"INSERT INTO OperationDetails (OperationId, ItemId, Quantity ) " +
        //                  $"VALUES ({operation.OperationId}, {operation.operationDetail}, {operation.operationDetail})";                          

        //    return _genericRepository.Add(sql);
        //}
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
                        string detailSql = string.Join(";", operation.operationDetail
                            .Select(detail => $"INSERT INTO OperationDetails (OperationId, ItemId, Quantity) " +
                                              $"VALUES ({operationId}, {detail.ItemId}, {detail.Quantity})"));

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

        public IEnumerable<Operationn> GetAll()
        {
            string sql = "SELECT * FROM Operation";
            return _genericRepository.GetAll(sql);
        }

        //public Operationn GetById(Operationn operationn)
        //{
        //    string sql = $"SELECT * FROM Operation WHERE OperationId = {operationn.OperationId}";
        //    return _genericRepository.GetById(sql);
        //}

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
