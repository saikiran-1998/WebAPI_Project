using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI_Project.Models
{
    public class Category
    {
        [Key]
        public int Category_ID { get; set; }
        public string Category_Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
