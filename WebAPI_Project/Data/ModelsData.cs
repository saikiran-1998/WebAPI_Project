using Microsoft.EntityFrameworkCore;
using WebAPI_Project.Models;

namespace WebAPI_Project.Data
{
    public static class ModelsData
    {
        public static void LoadData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Category_ID = 1, Category_Name = "Active Wear - Men" },
                new Category { Category_ID = 2, Category_Name = "Active Wear - Women" },
                new Category { Category_ID = 3, Category_Name = "Mineral Water" },
                new Category { Category_ID = 4, Category_Name = "Publications" },
                new Category { Category_ID = 5, Category_Name = "Supplements" });

            modelBuilder.Entity<Product>().HasData(
                new Product { Product_ID = 1, Category_ID = 1, Product_Name = "Grunge Skater Jeans", Product_Cost = 68 },
                new Product { Product_ID = 2, Category_ID = 1, Product_Name = "Polo Shirt", Product_Cost = 35 },
                new Product { Product_ID = 3, Category_ID = 1, Product_Name = "Skater Graphic T-Shirt", Product_Cost = 33 },
                new Product { Product_ID = 4, Category_ID = 1, Product_Name = "Slicker Jacket", Product_Cost = 125 },
                new Product { Product_ID = 5, Category_ID = 1, Product_Name = "Thermal Fleece Jacket", Product_Cost = 60 },
                new Product { Product_ID = 6, Category_ID = 1, Product_Name = "Unisex Thermal Vest", Product_Cost = 95 },
                new Product { Product_ID = 7, Category_ID = 1, Product_Name = "V-Neck Pullover", Product_Cost = 65, },
                new Product { Product_ID = 8, Category_ID = 1, Product_Name = "V-Neck Sweater", Product_Cost = 65 },
                new Product { Product_ID = 9, Category_ID = 1, Product_Name = "V-Neck T-Shirt", Product_Cost = 17 },
                new Product { Product_ID = 10, Category_ID = 2, Product_Name = "Bamboo Thermal Ski Coat", Product_Cost = 99 },
                new Product { Product_ID = 11, Category_ID = 2, Product_Name = "Cross-Back Training Tank", Product_Cost = 0 },
                new Product { Product_ID = 12, Category_ID = 2, Product_Name = "Grunge Skater Jeans", Product_Cost = 68 },
                 new Product { Product_ID = 17, Category_ID = 2, Product_Name = "V-Next T-Shirt", Product_Cost = 17 },
                new Product { Product_ID = 18, Category_ID = 3, Product_Name = "Blueberry Mineral Water", Product_Cost = 2.8 },
                new Product { Product_ID = 19, Category_ID = 3, Product_Name = "Lemon-Lime Mineral Water", Product_Cost = 2.8 },
                new Product { Product_ID = 20, Category_ID = 3, Product_Name = "Orange Mineral Water", Product_Cost = 2.8 },
                new Product { Product_ID = 21, Category_ID = 3, Product_Name = "Peach Mineral Water", Product_Cost = 2.8 },
                new Product { Product_ID = 22, Category_ID = 3, Product_Name = "Raspberry Mineral Water", Product_Cost = 2.8 },
                new Product { Product_ID = 23, Category_ID = 3, Product_Name = "Strawberry Mineral Water", Product_Cost = 2.8 },
                new Product { Product_ID = 24, Category_ID = 4, Product_Name = "In the Kitchen with H+ Sport", Product_Cost = 24.99 },
                new Product { Product_ID = 25, Category_ID = 5, Product_Name = "Calcium 400 IU (150 tablets)", Product_Cost = 9.99 },
                new Product { Product_ID = 26, Category_ID = 5, Product_Name = "Flaxseed Oil 100 mg (90 capsules)", Product_Cost = 12.49 },
                new Product { Product_ID = 27, Category_ID = 5, Product_Name = "Iron 65 mg (150 caplets)", Product_Cost = 13.99 },
                new Product { Product_ID = 28, Category_ID = 5, Product_Name = "Magnesium 250 mg (100 tablets)", Product_Cost = 12.49 });
        }
    }
}
