using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMarket.Models
{

    public class Category
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
    }
}
