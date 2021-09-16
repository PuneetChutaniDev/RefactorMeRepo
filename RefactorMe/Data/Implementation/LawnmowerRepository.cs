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
    public class LawnmowerRepository : BaseReadOnlyRepository<Product>
    {
        protected override Product[] Data {
            get {
                return new Lawnmower[] {
                    new Lawnmower() {
                        Id = Guid.NewGuid(),
                        Name = "Hewlett-Packard Rideable Lawnmower",
                        FuelEfficiency = "Very Low",
                        IsVehicle = true,
                        Price = 3000.0
                    },
                    new Lawnmower() {
                        Id = Guid.NewGuid(),
                        Name = "Fisher Price's My First Lawnmower",
                        FuelEfficiency = "Ultimate",
                        IsVehicle = false,
                        Price = 45.0
                    },
                    new Lawnmower() {
                        Id = Guid.NewGuid(),
                        Name = "Volkswagen LawnMaster 39000B Lawnmower",
                        FuelEfficiency = "Moderate",
                        IsVehicle = false,
                        Price = 1020.0
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
                    Type = ProductType.Lawnmover.ToString()
                });
            }
            return products.AsQueryable();
        }
    }
}
