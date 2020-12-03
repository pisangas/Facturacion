using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Contratos
{
    public interface IAccesoDatosProducto
    {
        List<Producto> ObtenerProductos();
        int InsertarProducto(Producto producto);
        List<Producto> RetornarProductos(string descripcion, string observaciones, int indicepagina, int tamanho);
        int CantidadProductos(string descripcion, string observaciones);
    }
}
