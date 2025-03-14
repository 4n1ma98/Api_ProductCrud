using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Business.Contracts
{
    public interface IProductValidation
    {
        Response Create_Product(CreateProductRequest request);
        Response Read_Product(int id);
        Response Update_Product(UpdateProductRequest request);
        Response Delete_Product(int id);
        Response Read_Products();
    }
}
