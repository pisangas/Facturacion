using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Contratos
{
    public interface IAccesoDatosCliente
    {
        int InsertarCliente(Cliente cliente);
        Cliente ObtenerCliente(int cedulaCliente);
        int ActualizarCliente(Cliente cliente);
        Task<int> EliminarClienteAsync(int id);
    }
}
