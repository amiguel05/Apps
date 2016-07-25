using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using OperacionesAgencia.Business.Engine.Contracts;
using OperacionesAgencia.Business.Entities.Models;
using OperacionesAgencia.Business.Entities.Models.Mapping;

using System.Data.Entity.ModelConfiguration.Conventions;

namespace OpeAgencia2.Infrastructure.Data.Context
{
    public class UnitOfWork : DbContext, IUnitOfWork
    {
        // Manuel A. Hernández. 14-1-2014
        /// <summary>
        /// Clase contenedora (Context) de las entidades del modelo.
        /// </summary>
        public DbSet<Empresas> Empresas { get; set; }
        public DbSet<Sucursales> Sucursales { get; set; }
        public DbSet<Organizaciones> Organizaciones { get; set; }
        public DbSet<Tipos> Tipos { get; set; }
        public DbSet<Cargos> Cargos { get; set; }
        public DbSet<CargosImpuestos> CargosImpuestos { get; set; }
        public DbSet<Estados> Estados { get; set; }
        public DbSet<GrupoEstados> GrupoEstados { get; set; }
        public DbSet<GruposTipos> GruposTipos { get; set; }
        public DbSet<ConceptoFacturas> ConceptoFacturas { get; set; }

        public UnitOfWork():base("name =ConexionPrueba")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EmpresasMap());
            modelBuilder.Configurations.Add(new SucursalesMap());
            modelBuilder.Configurations.Add(new OrganizacionesMap());
            modelBuilder.Configurations.Add(new TiposMap());
            modelBuilder.Configurations.Add(new CargosMap());
            modelBuilder.Configurations.Add(new CargosImpuestosMap());
            modelBuilder.Configurations.Add(new EstadosMap());
            modelBuilder.Configurations.Add(new GruposTiposMap());
            modelBuilder.Configurations.Add(new GruposEstadosMap());
            modelBuilder.Configurations.Add(new ConceptosFacturasMap());

            modelBuilder.Conventions.Remove(new PluralizingTableNameConvention());
            modelBuilder.Conventions.Remove(new OneToManyCascadeDeleteConvention());
            modelBuilder.Conventions.Remove(new ManyToManyCascadeDeleteConvention());

        }

        /// <summary>
        /// Permite guardar los cambios a una entidad.
        /// </summary>
        /// <returns>Retorna 1 si el proceso fue correcto. Si retorna 0 ha ocurrido un error.</returns>
        public new int SaveChanges()
        {
            var result = base.SaveChanges();

            return result;
        }

        /// <summary>
        /// Permite guardar los cambios en caso de ocurrir un bloqueo debido a concurrencia.
        /// </summary>
        public void RefreshAndCommit()
        {
            bool saveFailed = false;

            do
            {
                try
                {
                    SaveChanges();
                    saveFailed = false;
                }
                catch (DbUpdateConcurrencyException e)
                {
                    saveFailed = true;
                    e.Entries.ToList().ForEach(x => x.OriginalValues.SetValues(x.GetDatabaseValues()));
                }


            } while (saveFailed);
        }

        /// <summary>
        /// Permite deshacer los cambios realizados a una entidad especifica.
        /// </summary>
        public void RollBack()
        {
            base.ChangeTracker.Entries().ToList().ForEach(e => e.State = EntityState.Unchanged);
        }
    }
}
