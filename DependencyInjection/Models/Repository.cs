using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DependencyInjection.Models
{
    public class Repository : IRepository
    {
        private Dictionary <string, Product> products;
        public Repository()
        {
            products = new Dictionary<string, Product>();
            new List<Product>
            {
                new Product {Name =" Women Showes", Price = 99M},
                new Product {Name = "Skirtes" , Price = 29.99M},
                new Product {Name = "Pants" , Price = 40.5M}
            }.ForEach (p => AddProduct(p)) ;
        }
        public IEnumerable<Product> Products => products.Values; 
        public Product this[string name]=> products[name];
        public void AddProduct(Product product) => products[product.Name] = product;
        public void DeleteProduct(Product product) => products.Remove(product.Name);

        private string guid = System.Guid.NewGuid().ToString();
        public override string ToString()
        {
            return guid;
        }
    }
}
