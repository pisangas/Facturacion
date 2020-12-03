using AccesoDatos.Contratos;
using Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class AccesoDatosCliente : IAccesoDatosCliente
    {
        private Contexto _contexto;
        public AccesoDatosCliente(Contexto contexto)
        {
            _contexto = contexto;
        }

        public int ActualizarCliente(Cliente cliente)
        {
            int numeroRegistrosActualizados = 0;

            using (var transaccion = _contexto.Database.BeginTransaction())
            {
                try
                {
                    _contexto.Entry(cliente).State = EntityState.Modified;
                    numeroRegistrosActualizados = _contexto.SaveChanges();
                    transaccion.Commit();
                }
                catch (Exception ex)
                {
                    numeroRegistrosActualizados = 0;
                    transaccion.Rollback();
                    throw ex.InnerException;                    
                }
            }
            return numeroRegistrosActualizados;

        }

        public async Task<int> EliminarClienteAsync(int id)
        {
            Cliente cliente = await _contexto.Clientes.FindAsync(id);
            _contexto.Clientes.Remove(cliente);
            return await _contexto.SaveChangesAsync();
        }

        public int InsertarCliente(Cliente cliente)
        {
            _contexto.Clientes.Add(cliente);
            return _contexto.SaveChanges();
        }
        public Cliente ObtenerCliente(int cedulaCliente)
        {
           return _contexto.Clientes.FirstOrDefault(c => c.Cedula == cedulaCliente);           
        }


    }
}
