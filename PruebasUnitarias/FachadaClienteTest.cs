using System;
using AccesoDatos.Contratos;
using LogicaNegocio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modelos;
using Moq;

namespace PruebasUnitarias
{
    [TestClass]
    public class FachadaClienteTest
    {
        private Mock<IAccesoDatosCliente> _mockAccesoDatosCliente;
        private FachadaCliente _fachadaCliente;

        [TestInitialize]

        public void Inicializar()
        {
            _mockAccesoDatosCliente = new Mock<IAccesoDatosCliente>();
            _mockAccesoDatosCliente.Setup(c => c.InsertarCliente(It.IsAny<Cliente>())).Returns(1);

            _fachadaCliente = new FachadaCliente(_mockAccesoDatosCliente.Object);
        }

        [TestMethod]
        public void InsertarClienteMayorEdad()
        {
            Cliente cliente = new Cliente
            {
                NombreCliente = "Luz",
                FechaNacimiento = new DateTime(1983, 03, 10)
            };

            Assert.IsTrue(_fachadaCliente.InsertarCliente(cliente));

        }

        [TestMethod]
        public void InsertarClienteMenorEdad()
        {
            Cliente cliente = new Cliente
            {
                NombreCliente = "Luz",
                FechaNacimiento = new DateTime(2015, 03, 10)
            };

            Assert.IsFalse(_fachadaCliente.InsertarCliente(cliente));

        }
    }
}
