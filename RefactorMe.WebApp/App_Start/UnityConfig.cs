using RefactorMe.Data;
using RefactorMe.Data.Implementation;
using RefactorMe.Models;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace RefactorMe.WebApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            //container.RegisterType<BaseReadOnlyRepository<Product>, LawnmowerRepository>();
            //container.RegisterType<BaseReadOnlyRepository<Product>, PhoneCaseRepository>();
            //container.RegisterType<BaseReadOnlyRepository<Product>, TShirtRepository>();
            container.RegisterType<IProductDataConsolidator, ProductDataConsolidator>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}