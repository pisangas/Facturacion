using LogicaNegocio;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FacturacionMVC.Controllers
{
    public class ProductosController : Controller
    {
        private FachadaProducto _fachadaProducto;
        public ProductosController(FachadaProducto fachadaProducto)
        {
            _fachadaProducto = fachadaProducto;
        }

        // GET: Productos
        public ActionResult Index()
        {
            return View(_fachadaProducto.ObtenerProductos());
        }

        public ActionResult CrearProducto(Producto producto)
        {
            return View(_fachadaProducto.InsertarProducto(producto));
        }



    }
}