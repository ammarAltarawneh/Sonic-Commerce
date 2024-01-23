using Azure;
using DAL.Managers;
using DAL.Models;
using Models;
using static DAL.Enum;

namespace BAL.Services
{
    public class OperationService
    {
        private readonly OperationManager _operationManager;
        private readonly IUser _user;
        public OperationService(IUser user)
        {
            _user = user;
            _operationManager = new OperationManager(user);
        }

        public EnumResult Add(Operationn operation)
        {
            try
            {
                EnumResult result = _operationManager.AddTransaction(operation);

                return result;
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

        public IEnumerable<OperationInAngular> GetAll()
        {
            return _operationManager.GetAll();
        }
    }

}
