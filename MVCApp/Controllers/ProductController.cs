using Business.Abstracts;
using Business.Concretes;
using DataAccess.Concretes.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MVCApp.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View(_productService.GetAll());
        }
    }
}
