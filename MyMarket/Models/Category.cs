using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMarket.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        [Column("Category_Id")]
        public int Id { get; set; }
        [Key]
        [Column("Category_Name")]
        public string? Name { get; set; }
    }
}
