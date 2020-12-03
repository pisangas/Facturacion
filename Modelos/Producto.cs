using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    [Table("Productos")]
    public class Producto
    {
        public int ProductoId { get; set; }
        
        [StringLength(120, ErrorMessage ="El campo {0} debe terner entre {2} y {1} caracteres")]
        [Required (ErrorMessage = "Debe ingresar el campo {0}")]
        public string Descripcion { get; set; }

        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string Observaciones { get; set; }

    }
}
