using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class UpdateProductRequest
    {
        [Required(ErrorMessage = "El campo Id es obligatorio.")]
        public int? Id {  get; set; }
        [Required(ErrorMessage = "El campo Price es obligatorio.")]
        [Range(0, 10000000, ErrorMessage = "El precio no puede ser menos de 0 ni más de 10.000.000.")]
        public int? Price {  get; set; }
        [Required(ErrorMessage = "El campo Stock es obligatorio.")]
        [Range(0, 1000, ErrorMessage = "El precio no puede ser menos de 0 ni más de 1.000.")]
        public int? Stock {  get; set; }
    }
}
