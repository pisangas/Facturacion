using AccesoDatos.Contratos;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class FachadaCliente
    {
        private IAccesoDatosCliente _accesoDatosCliente;

        public FachadaCliente(IAccesoDatosCliente accesoDatosCliente)
        {
            _accesoDatosCliente = accesoDatosCliente;
        }
        public bool InsertarCliente(Cliente cliente)
        {
            int edad = DateTime.Now.AddTicks(-cliente.FechaNacimiento.Ticks).Year - 1;

            if (edad < 18)
            {
                return false;
            }            
            return _accesoDatosCliente.InsertarCliente(cliente)  == 1;
        }

        public Cliente ObtenerCliente(int cedulaCliente)
        {
            return _accesoDatosCliente.ObtenerCliente(cedulaCliente);
        }

        public bool ActualizarCliente(Cliente cliente)
        {
            return _accesoDatosCliente.ActualizarCliente(cliente) == 1;
        }

        public async Task<bool> EliminarClienteAsync (int id)
        {
            return await _accesoDatosCliente.EliminarClienteAsync(id) == 1;
        }
    }
}
