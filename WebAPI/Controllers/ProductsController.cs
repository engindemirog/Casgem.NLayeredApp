using Business.Abstracts;
using Business.Dtos;
using Business.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public List<ListProductDto> GetAll()
        {
            return _productService.GetAll();
        }

        [HttpPost("add")]
        public void Add(CreateProductRequest createProductRequest)
        {
            _productService.Add(createProductRequest);
        }
    }
}
