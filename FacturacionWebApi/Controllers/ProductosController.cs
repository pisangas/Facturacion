using FacturacionWebApi.Models;
using LogicaNegocio;
using Modelos;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace FacturacionWebApi.Controllers
{    
    public class ProductosController : ApiController
    {
        private FachadaProducto _fachadaProducto;
        public ProductosController(FachadaProducto fachadaProducto)
        {
            _fachadaProducto = fachadaProducto;
        }
        //public IEnumerable<Producto> GetProductos()
        //{
        //    return _fachadaProducto.ObtenerProducto();
        //}

        public object Get()
        {
            ProductoFiltro productoFiltro = ObtenerFiltro();
            var resultado = _fachadaProducto.RetornarProductos(productoFiltro.Descripcion, productoFiltro.Observaciones, productoFiltro.IndicePagina.Value, productoFiltro.TamanhoPagina.Value);

            var resultadoGrid = new JSGridResponse<Producto>
            {
                data = resultado,
                itemsCount = _fachadaProducto.CantidadProductos(productoFiltro.Descripcion, productoFiltro.Observaciones)
            };
            return resultadoGrid;
        }


        #region Insertar Producto
        //[ResponseType(typeof(void))]
        public IHttpActionResult PostProducto(Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_fachadaProducto.InsertarProducto(producto))
            {
                return Ok("Ingresado ok");
            }
            return BadRequest("Error al insertar el producto");
        }
        #endregion

        #region JSGrid
        private Models.ProductoFiltro ObtenerFiltro()
        {
            NameValueCollection filtro = HttpUtility.ParseQueryString(Request.RequestUri.Query);
            return new ProductoFiltro
            {
                Descripcion = filtro["Descripcion"],
                Observaciones = filtro["Observaciones"],
                IndicePagina = String.IsNullOrEmpty(filtro["pageIndex"]) ? (int?)null : Convert.ToInt32(filtro["pageIndex"]),
                TamanhoPagina = String.IsNullOrEmpty(filtro["pageSize"]) ? (int?)null : Convert.ToInt32(filtro["pageSize"]),
            };
        }
        #endregion
    }
}
