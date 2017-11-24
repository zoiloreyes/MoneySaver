namespace FinanzasPersonales.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<FinanzasPersonales.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FinanzasPersonales.Models.ApplicationDbContext context)
        {

            context.EstadoCategoria.AddOrUpdate(x => x.EstadoCategoriaID,
                new EstadoCategoria() { EstadoCategoriaID = 1, Estado = "Activo" },
                new EstadoCategoria() { EstadoCategoriaID = 2, Estado = "Inactivo" }
                );

            context.EstadoCuentaBanco.AddOrUpdate(y => y.EstadoCuentaBancoID,
                new EstadoCuentaBanco() { EstadoCuentaBancoID = 1, Estado = "Activo" },
                new EstadoCuentaBanco() { EstadoCuentaBancoID = 2, Estado = "Inactivo" }
                );

            context.EstadoTarjetaCredito.AddOrUpdate(y => y.EstadoTarjetaCreditoID,
                new EstadoTarjetaCredito() { EstadoTarjetaCreditoID = 1, Estado = "Activo" },
                new EstadoTarjetaCredito() { EstadoTarjetaCreditoID = 2, Estado = "Inactivo" }
                );

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
