using Azure;
using DAL.Managers;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DAL.Enum;

namespace BAL.Services
{
    public class OperationService
    {
        private readonly OperationManager _operationManager;

        public OperationService()
        {
            _operationManager = new OperationManager();
        }

        public EnumResult Add(Operationn operation)
        {
            try
            {
                return _operationManager.Add(operation);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occurred " + ex.ToString());
                return EnumResult.Fail;
            }
        }

        public EnumResult Update(Operationn operation)
        {
            try
            {
                return _operationManager.Update(operation);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occurred " + ex.ToString());
                return EnumResult.Fail;
            }
        }

        public EnumResult Delete(int id)
        {
            try
            {
                return _operationManager.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occurred " + ex.ToString());
                return EnumResult.Fail;
            }
        }

        public IEnumerable<Operationn> GetAll()
        {
            return _operationManager.GetAll();
        }
    }

}
