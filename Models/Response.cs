using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Response
    {
        public int IdError { get; set; }
        public string Message { get; set; }
        public object? AdditionalData { get; set; } = null;
    }
}
