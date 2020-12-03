namespace AccesoDatos.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AccesoDatos.SQLServer.ContextoSQLServer>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "AccesoDatos.SQLServer.ContextoSQLServer";
        }
        protected override void Seed(AccesoDatos.SQLServer.ContextoSQLServer context)
        {
            context.Productos.AddOrUpdate(

                p => p.Descripcion,
                new Modelos.Producto { Descripcion = "Mac", Precio = 1200000, Stock = 2, Observaciones = "Family" });            
        }
    }
}
