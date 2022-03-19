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
            Thread.Sleep(3000);
            return _productService.GetAll();
        }

        [HttpGet("getbyid/{id}")]
        public GetProductDto GetAll([FromRoute] int id)
        {
            return _productService.GetById(id);
        }

        [HttpPost("add")]
        public void Add(CreateProductRequest createProductRequest)
        {
            _productService.Add(createProductRequest);
        }

        [HttpPost("update")]
        public void Update(UpdateProductRequest updateProductRequest)
        {
            _productService.Update(updateProductRequest);
        }
    }
}
