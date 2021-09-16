using RefactorMe.Models;
using System.Collections.Generic;

namespace RefactorMe
{
    public interface IProductDataConsolidator
    {
        List<Product> GetAll(Currency? Currency);
    }
}