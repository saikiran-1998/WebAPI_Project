using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAPI_Project.Models
{
    public class Product
    {
        [Key]
        public int Product_ID { get; set; }
        public string Product_Name { get; set; }
        public double Product_Cost { get; set; }
        public int Category_ID { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }
    }
}
