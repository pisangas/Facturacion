using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturacionWebApi.Models
{
    public class ProductoFiltro
    {
        public string Descripcion { get; set; }
        public string Observaciones { get; set; }
        public int? IndicePagina { get; set; }
        public int? TamanhoPagina { get; set; }
    }
}