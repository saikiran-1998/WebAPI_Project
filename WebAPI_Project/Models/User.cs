using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI_Project.Models
{
    public class User
    {
        [Key]
        public int User_Id { get; set; }
        public string User_Name { get; set; }
        public List<Order> Orders { get; set; }
       
    }
}
