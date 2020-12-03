using System;
using System.Threading.Tasks;
using AccesoDatos;
using AccesoDatos.Contratos;
using AccesoDatos.SQLServer;
using LogicaNegocio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modelos;
using Unity;

namespace PruebasIntegracion
{
    [TestClass]
    public class FachadaClienteTestIntegracion
    {
        IUnityContainer _unityContainer;
        FachadaCliente _fachadaCliente;

        [TestInitialize]
        public void Inicializar()
        {
            _unityContainer = new UnityContainer();

            _unityContainer.RegisterType<Contexto, ContextoSQLServer>();
            _unityContainer.RegisterType<IAccesoDatosCliente, AccesoDatosCliente>();

            _fachadaCliente = _unityContainer.Resolve<FachadaCliente>();
        }

        [TestMethod]
        public void InsertarClienteBD()
        {
            Cliente cliente = new Cliente
            {
                NombreCliente = "Eduardo Gil",
                Cedula = 54021038,
                FechaNacimiento = new DateTime(1983, 03, 10)
            };

            _fachadaCliente.InsertarCliente(cliente);
            Cliente clienteIngresado = _fachadaCliente.ObtenerCliente(cliente.Cedula);

            Assert.AreEqual(cliente, clienteIngresado);
        }

        [TestMethod]
        public void ActualizarClienteBDExitoso()
        {
            Cliente cliente = new Cliente
            {
                NombreCliente = "Luis Gil",
                Cedula = 14396325,
                FechaNacimiento = new DateTime(1980, 03, 10)
            };

            _fachadaCliente.InsertarCliente(cliente);
            cliente.NombreCliente = "Eduardo Martinez";
             _fachadaCliente.ActualizarCliente(cliente);
            Cliente clienteActualizado = _fachadaCliente.ObtenerCliente(cliente.Cedula);           
            
            Assert.AreEqual(cliente, clienteActualizado);
        }

        [TestMethod]
        public async Task EliminarClienteAsyncExitoso()
        {
            Cliente cliente = new Cliente
            {
                NombreCliente = "Javier Mejia",
                Cedula = 54120365,
                FechaNacimiento = new DateTime(1975, 04, 09)
            };

            _fachadaCliente.InsertarCliente(cliente);
            Cliente clienteEliminar = _fachadaCliente.ObtenerCliente(cliente.Cedula);
            
            Assert.IsTrue(await _fachadaCliente.EliminarClienteAsync(clienteEliminar.ClienteId));
        }

    }
}
