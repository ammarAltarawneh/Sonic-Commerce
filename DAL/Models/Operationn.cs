using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Operationn
    {
        public int OperationId { get; set; }
        public int UserId { get; set; }
        public int OperationTypeId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OperationDate { get; set; }
        public decimal TaxTotal { get; set; }
        public decimal DiscountTotal { get; set; }
        public decimal GrossTotal { get; set; }
        public decimal NetTotal { get; set; }
        public List<OperationDetail> operationDetail { get; set; }
    }
}