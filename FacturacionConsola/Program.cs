using AccesoDatos.Contratos;
using AccesoDatos.SQLServer;
using AccesoDatos;
using LogicaNegocio;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace FacturacionConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IUnityContainer unityContainer = new UnityContainer();

                unityContainer.RegisterType<Contexto, ContextoSQLServer>();
                unityContainer.RegisterType<IAccesoDatosCliente, AccesoDatosCliente>();

                FachadaCliente fachadaCliente = unityContainer.Resolve<FachadaCliente>();

                Cliente cliente = new Cliente
                {
                    NombreCliente = "Milena Rodriguez"
                };

                fachadaCliente.InsertarCliente(cliente);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("ok");
                Console.ReadLine();
            }

        }
    }
}
