using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Business.Contracts;
using DataAccess.Contracts;
using Models;
using Models.Entities;

namespace Business
{
    public class ProductValidation : IProductValidation
    {
        private readonly IProductCrud _productCrud;

        public ProductValidation(IProductCrud productCrud)
        {
            _productCrud = productCrud;
        }

        public Response Create_Product(CreateProductRequest request)
        {
            Product product = new()
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Stock = request.Stock,
            };

            return _productCrud.Create(product);
        }

        public Response Read_Product(int id)
        {
            Product product = new()
            {
                Id = id
            };

            return _productCrud.Read(product);
        }

        public Response Update_Product(UpdateProductRequest request)
        {
            Product product = new()
            {
                Id = request.Id!.Value,
                Price = request.Price!.Value,
                Stock = request.Stock!.Value,
            };

            return _productCrud.Update(product);
        }

        public Response Delete_Product(int id)
        {
            Product product = new()
            {
                Id = id,
            };

            return _productCrud.Delete(product);
        }

        public Response Read_Products()
        {
            return _productCrud.ReadAll();
        }
    }
}
