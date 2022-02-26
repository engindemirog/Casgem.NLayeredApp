using Business.Concretes;
using DataAccess.Concretes.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MVCApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            return View(productManager.GetAll());
        }
    }
}
