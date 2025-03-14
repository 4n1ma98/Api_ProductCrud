using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataAccess.Contracts;
using Microsoft.Extensions.Configuration;
using Models;
using Models.Entities;

namespace DataAccess
{
    public class ProductCrud : IProductCrud
    {
        private readonly DBContext _dBContext;
        private readonly IConfiguration _config;
        private readonly IErrorCode _errorCode;
        private readonly IErrorLog _errorLog;

        public ProductCrud(DBContext dBContext, IConfiguration config, IErrorCode errorCode, IErrorLog errorLog)
        {
            _dBContext = dBContext;
            _config = config;
            _errorCode = errorCode;
            _errorLog = errorLog;
        }

        public Response Create(Product product)
        {
            var parameters = new
            {
                Option = 1,
                product.Name,
                product.Description,
                product.Price,
                product.Stock,
            };

            try
            {
                using (IDbConnection _context = _dBContext.Conn(_config.GetConnectionString("DefaultConnection")!))
                {
                    _context.Execute("SP_ProductCRUD", parameters, commandTimeout: 600, commandType: CommandType.StoredProcedure);
                    return _errorCode.GetError(0);
                }
            }
            catch (Exception ex)
            {
                _errorLog.Register("ProductCrud/Create", ex.Message);
                return _errorCode.GetError(-999, ex);
            }
        }

        public Response Read(Product product)
        {
            try
            {
                var parameters = new
                {
                    Option = 2,
                    product.Id,
                };

                using (IDbConnection _context = _dBContext.Conn(_config.GetConnectionString("DefaultConnection")!))
                {
                    return _errorCode.GetError(0, _context.Query<Product>("SP_ProductCRUD", parameters, commandTimeout: 600, commandType: CommandType.StoredProcedure).ToList());
                }
            }
            catch (Exception ex)
            {
                _errorLog.Register("ProductCrud/Read", ex.Message);
                return _errorCode.GetError(-999, ex);
            }
        }

        public Response Update(Product product)
        {
            var parameters = new
            {
                Option = 3,
                product.Id,
                product.Price,
                product.Stock,
            };

            try
            {
                using (IDbConnection _context = _dBContext.Conn(_config.GetConnectionString("DefaultConnection")!))
                {
                    _context.Execute("SP_ProductCRUD", parameters, commandTimeout: 600, commandType: CommandType.StoredProcedure);
                    return _errorCode.GetError(0);
                }
            }
            catch (Exception ex)
            {
                _errorLog.Register("ProductCrud/Update", ex.Message);
                return _errorCode.GetError(-999, ex);
            }
        }

        public Response Delete(Product product)
        {
            var parameters = new
            {
                Option = 4,
                product.Id,
            };

            try
            {
                using (IDbConnection _context = _dBContext.Conn(_config.GetConnectionString("DefaultConnection")!))
                {
                    _context.Execute("SP_ProductCRUD", parameters, commandTimeout: 600, commandType: CommandType.StoredProcedure);
                    return _errorCode.GetError(0);
                }
            }
            catch (Exception ex)
            {
                _errorLog.Register("ProductCrud/Delete", ex.Message);
                return _errorCode.GetError(-999, ex);
            }
        }

        public Response ReadAll()
        {
            try
            {
                var parameters = new
                {
                    Option = 5,
                };

                using (IDbConnection _context = _dBContext.Conn(_config.GetConnectionString("DefaultConnection")!))
                {
                    return _errorCode.GetError(0, _context.Query<Product>("SP_ProductCRUD", parameters, commandTimeout: 600, commandType: CommandType.StoredProcedure).ToList());
                }
            }
            catch (Exception ex)
            {
                _errorLog.Register("ProductCrud/ReadAll", ex.Message);
                return _errorCode.GetError(-999, ex);
            }
        }
    }
}
