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
    public class PhoneCaseRepository : BaseReadOnlyRepository<Product>
    {
        protected override Product[] Data {
            get {
                return new PhoneCase[] {
                    new PhoneCase() { 
                        Id = Guid.NewGuid(),
                        Name = "Amazon Fire Burgundy Phone Case",
                        Colour = "Burgundy",
                        Material = "PVC",
                        TargetPhone = "Amazon Fire",
                        Price = 14.0
                    },
                    new PhoneCase() {
                        Id = Guid.NewGuid(),
                        Name = "Nokia Lumia 920/930/Icon Crimson Phone Case",
                        Colour = "Red",
                        Material = "Rubber",
                        TargetPhone = "Nokia Lumia 920/930/Icon",
                        Price = 10.0
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
                    Type = ProductType.PhoneCase.ToString()
                });
            }
            return products.AsQueryable();
        }
    }
}
