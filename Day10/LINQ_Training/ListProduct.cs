using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Training
{
    public class ListProduct
    {
        public List<Product> products { get; set; }
        public ListProduct()
        {
            products = new List<Product>();

            products.AddRange(new List<Product>
        {
            new Product { Name = "Product 1", Category = "Category A", Price = 10.99m, Stock = 100 },
            new Product { Name = "Product 2", Category = "Category A", Price = 15.49m, Stock = 200 },
            new Product { Name = "Product 3", Category = "Category B", Price = 8.99m, Stock = 150 },
            new Product { Name = "Product 4", Category = "Category B", Price = 20.99m, Stock = 80 },
            new Product { Name = "Product 5", Category = "Category C", Price = 12.99m, Stock = 120 },
            new Product { Name = "Product 6", Category = "Category C", Price = 9.49m, Stock = 60 },
            new Product { Name = "Product 7", Category = "Category D", Price = 25.99m, Stock = 90 },
            new Product { Name = "Product 8", Category = "Category D", Price = 19.99m, Stock = 110 },
            new Product { Name = "Product 9", Category = "Category E", Price = 14.99m, Stock = 50 },
            new Product { Name = "Product 10", Category = "Category E", Price = 18.49m, Stock = 70 },
            new Product { Name = "Product 11", Category = "Category F", Price = 17.99m, Stock = 95 },
            new Product { Name = "Product 12", Category = "Category F", Price = 22.49m, Stock = 85 },
            new Product { Name = "Product 13", Category = "Category G", Price = 24.99m, Stock = 40 },
            new Product { Name = "Product 14", Category = "Category G", Price = 11.99m, Stock = 55 },
            new Product { Name = "Product 15", Category = "Category H", Price = 13.99m, Stock = 130 },
            new Product { Name = "Product 16", Category = "Category H", Price = 21.49m, Stock = 75 },
            new Product { Name = "Product 17", Category = "Category I", Price = 16.99m, Stock = 65 },
            new Product { Name = "Product 18", Category = "Category I", Price = 23.99m, Stock = 150 },
            new Product { Name = "Product 19", Category = "Category J", Price = 27.49m, Stock = 140 },
            new Product { Name = "Product 20", Category = "Category J", Price = 29.99m, Stock = 200 }
        });
        }
    }
}
