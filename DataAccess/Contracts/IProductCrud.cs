using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Entities;

namespace DataAccess.Contracts
{
    public interface IProductCrud
    {
        Response Create(Product product);
        Response Read(Product product);
        Response Update(Product product);
        Response Delete(Product product);
        Response ReadAll();
    }
}
