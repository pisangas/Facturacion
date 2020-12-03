using AccesoDatos.Contratos;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class FachadaProducto
    {
        private IAccesoDatosProducto _accesoDatosProducto;

        public FachadaProducto(IAccesoDatosProducto accesoDatosProducto)
        {
            _accesoDatosProducto = accesoDatosProducto;
        }
        public List<Producto> ObtenerProducto()
        {
            return _accesoDatosProducto.ObtenerProductos();
        }
        public bool InsertarProducto(Producto producto)
        {
            return _accesoDatosProducto.InsertarProducto(producto) == 1;
        }

        public List<Producto> RetornarProductos(string descripcion, string observaciones, int indicePagina, int tamanho)
        {
            return _accesoDatosProducto.RetornarProductos(descripcion, observaciones, indicePagina, tamanho);
        }

        public int CantidadProductos (string descripcion, string observaciones)
        {
            return _accesoDatosProducto.CantidadProductos(descripcion, observaciones);

        }
    }
}
