using DAL.Managers;
using DAL.Models;
using MyMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DAL.Enum;

namespace BAL.Services
{
    public class ItemService
    {
        private readonly ItemManager _itemManager;

        public ItemService()
        {
            _itemManager = new ItemManager();
        }

        public EnumResult Add(Item item)
        {
            try
            {
                return _itemManager.Add(item);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occured " + ex.ToString());
                return EnumResult.Fail;
            }
        }
        public EnumResult Update(Item item)
        {
            try
            {
                return _itemManager.Update(item);
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
                return _itemManager.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occured " + ex.ToString());
                return EnumResult.Fail;
            }
        }

        public IEnumerable<Item> GetAll()
        {
            return _itemManager.GetAll();
        }
    }
}
