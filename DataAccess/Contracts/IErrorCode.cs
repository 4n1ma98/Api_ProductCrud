using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccess.Contracts
{
    public interface IErrorCode
    {
        Response GetError(int idError, object? additionalData = null);
    }
}
