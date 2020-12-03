using AccesoDatos;
using AccesoDatos.Contratos;
using AccesoDatos.SQLServer;
using FacturacionMVC.Controllers;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace FacturacionMVC
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());

            container.RegisterType<Contexto, ContextoSQLServer>();
            container.RegisterType<IAccesoDatosProducto, AccesoDatosProducto>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}