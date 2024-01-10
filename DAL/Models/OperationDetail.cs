using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class OperationDetail
    {
        public int OperationId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
    }
}
