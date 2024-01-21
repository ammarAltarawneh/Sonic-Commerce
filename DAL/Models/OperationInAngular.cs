using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class OperationInAngular
    {
        public int OperationId { get; set; }
        public string OperationTypeName { get; set; }
        public string CustomerName { get; set; }
        public DateTime OperationDate { get; set; }
        public decimal GrossTotal { get; set; }
        public decimal NetTotal { get; set; }
    }
}
