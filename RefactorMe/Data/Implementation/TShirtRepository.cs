using RefactorMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RefactorMe.Data.Implementation
{
    /// <summary>
    /// Every module is independent and should have only one reason to change 
    /// This will perform its own job
    /// </summary>
    public class TShirtRepository : BaseReadOnlyRepository<Product>
    {
        protected override Product[] Data {
            get {
                return new TShirt[] {
                    new TShirt() {
                        Id = Guid.NewGuid(),
                        Colour = "Blue",
                        Name = "Xamarin C# T-Shirt",
                        Price = 15.0,
                        ShirtText = "C#, Xamarin"
                    },
                    new TShirt() {
                        Id = Guid.NewGuid(),
                        Colour = "Black",
                        Name = "New York Yankees T-Shirt",
                        Price = 8.0,
                        ShirtText = "NY"
                    },
                    new TShirt() {
                        Id = Guid.NewGuid(),
                        Colour = "Green",
                        Name = "Disney Sleeping Beauty T-Shirt",
                        Price = 10.0,
                        ShirtText = "Mirror mirror on the wall..."
                    }
                };
            }
        }

        protected override IQueryable<Product> GetProducts(double changePrice = 1)
        {
            var products = new List<Product>();
            foreach (var i in Data)
            {
                products.Add(new Product()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Price = i.Price * changePrice,
                    Type = ProductType.TShirt.ToString()
                });
            }
            return products.AsQueryable();
        }
    }
}
