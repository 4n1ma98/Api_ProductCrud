﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UpdateProductRequest
    {
        public int Id {  get; set; }
        public int Price {  get; set; }
        public int Stock {  get; set; }
    }
}
