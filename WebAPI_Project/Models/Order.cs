using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAPI_Project.Models
{
    public class Order
    {
        [Key]
        public int Order_Id { get; set; }
        public int User_ID { get; set; }
        public List<Product> Products { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
    }
}
