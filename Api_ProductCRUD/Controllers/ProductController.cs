using Business.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Api_ProductCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductValidation _productValidation;

        public ProductController(IProductValidation productValidation)
        {
            _productValidation = productValidation;
        }

        [HttpPost("[action]")]
        public IActionResult CreateProduct(CreateProductRequest request)
        {
            Response response = _productValidation.Create_Product(request);

            if (response.IdError == 0) return Ok(response);
            else if (response.IdError == -999) return StatusCode(500, response);
            else return BadRequest(response);
        }

        [HttpGet("[action]/{id?}")]
        public IActionResult ReadProduct(int? id = null)
        {
            Response response = new();

            if (id == null)
                response = _productValidation.Read_Products();
            else
                response = _productValidation.Read_Product(id.Value);


            if (response.IdError == 0)
                return Ok(response);
            else if (response.IdError == -999)
                return StatusCode(500, response);
            else
                return BadRequest(response);
        }

        [HttpPut("[action]")]
        public IActionResult UpdateProduct(UpdateProductRequest request)
        {
            Response response = _productValidation.Update_Product(request);

            if (response.IdError == 0)
                return Ok(response);
            else if (response.IdError == -999)
                return StatusCode(500, response);
            else
                return BadRequest(response);
        }

        [HttpDelete("[action]/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            Response response = _productValidation.Delete_Product(id);

            if (response.IdError == 0)
                return Ok(response);
            else if (response.IdError == -999)
                return StatusCode(500, response);
            else
                return BadRequest(response);
        }
    }
}
