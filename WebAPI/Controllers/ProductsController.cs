using Business.Abstracts;
using Business.Dtos;
using Business.Requests;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public List<ListProductDto> GetAll()
        {
            Thread.Sleep(1000);
            return _productService.GetAll();
        }

        [HttpGet("getallbycategory/{id}")]
        public List<ListProductDto> GetAllByCategory([FromRoute]  int id)
        {
            Thread.Sleep(1000);
            return _productService.GetAllByCategory(id);
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
