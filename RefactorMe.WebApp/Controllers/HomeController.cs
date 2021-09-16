using Newtonsoft.Json;
using RefactorMe.Models;
using System.Web.Mvc;

namespace RefactorMe.WebApp.Controllers
{
    /// <summary>
    /// Dependency injection (use of IOC container)
    /// Pros: Maintainable, No modular dependency
    /// </summary>
    public class HomeController : Controller
    {
        private readonly IProductDataConsolidator _productDataConsolidator;
        public HomeController(IProductDataConsolidator productDataConsolidator)
        {
            _productDataConsolidator = productDataConsolidator;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllProducts(Currency? currency)
        {
            var products = _productDataConsolidator.GetAll(currency);
            return Json(new { products = JsonConvert.SerializeObject(products) }, JsonRequestBehavior.AllowGet);
        }
    }
}