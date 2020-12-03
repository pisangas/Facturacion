using AccesoDatos.Contratos;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    class AccesoDatosProducto : IAccesoDatosProducto
    {
        private Contexto _contexto;

        public AccesoDatosProducto(Contexto contexto)
        {
            _contexto = contexto;
        }

        public int CantidadProductos(string descripcion, string observaciones)
        {
            var productos = _contexto.Productos.Where(p => (String.IsNullOrEmpty(descripcion) || (p.Descripcion.Contains(descripcion))));
            return productos.ToArray().Count();
        }

        public int InsertarProducto(Producto producto)
        {
            _contexto.Productos.Add(producto);
            return _contexto.SaveChanges();
        }

        public List<Producto> ObtenerProductos()
        {
            return _contexto.Productos.ToList();
        }

        public List<Producto> RetornarProductos(string descripcion, string observaciones, int indicePagina, int tamanho)
        {
            var productos = _contexto.Productos.Where(p => (String.IsNullOrEmpty(descripcion) || (p.Descripcion.Contains(descripcion)))).OrderBy(p => p.ProductoId).Skip((indicePagina - 1) * tamanho).Take(tamanho);

            return productos.ToList();
        }
    }
}
