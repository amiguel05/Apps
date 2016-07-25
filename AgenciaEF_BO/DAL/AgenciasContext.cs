using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaEF_BO.Models;
using AgenciaEF_BO.Models.VW;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace AgenciaEF_BO.DAL
{
    public class AgenciasContext : DbContext
    {
        public AgenciasContext()
            : base("dbepsContext")
        {

        }

        
        public DbSet<Opciones> Opciones { get; set; }
        public DbSet<Empresas> Empresas { get; set; }
        public DbSet<Sucursales> Sucursales { get; set; }
        public DbSet<Suplidores> Suplidores { get; set; }
        public DbSet<Origen> Origen { get; set; }
        public DbSet<GruposTipos> GruposTipos { get; set; }
        public DbSet<GruposEstados> GruposEstados { get; set; }
        public DbSet<GruposCodigos> GruposCodigos { get; set; }
        public DbSet<vw_usuario_opciones> vwUsuarioOpciones { set; get; }
        //
        public DbSet<Estados> Estados { get; set; }
        public DbSet<Tipos> Tipos { get; set; }
        public DbSet<Codigos> Codigos { get; set; }
        //
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Cargos> Cargos { get; set; }
        //
        public DbSet<TasaCambio> TasaCambio { get; set; }
        public DbSet<CargosProducto> CargosProducto { get; set; }
        public DbSet<CargosValores> CargosValores { get; set; }
        //Seguridad
        public DbSet<Modulos> Modulos { set; get; }
        public DbSet<Usuarios> Usuarios {set; get;}
        public DbSet<UsuarioSucursal> UsuarioSucursal { set; get; }
        public DbSet<UsuariosModulos> UsuariosModulos { set; get; }
        public DbSet<UsuariosOpciones> UsuariosOpciones { set; get; }
        public DbSet<Roles> Roles { set; get; }
        public DbSet<RolesOpciones> RolesOpciones { set; get; }
        public DbSet<UsuariosRoles> UsuariosRoles { set; get; }

        //Administracion de clientes
        public DbSet<Clientes> Clientes { set; get; }
        public DbSet<Bultos> Bultos { set; get; }
        public DbSet<BultosValores> BultosValores { set; get; }
        public DbSet<EquivalenciaBultos> EquivalenciaBultos { set; get; }
        //
        public DbSet<ParametrosSucursal> ParametrosSucursal  { set; get; }
        //
        public DbSet<vw_bultos_valores> vwBultosValores { set; get; }

        public DbSet<Recibos> Recibos { set; get; }
        public DbSet<RecibosDet> RecibosDet { set; get; }


        public DbSet<MovCaja> MovCaja { set; get; }
        public DbSet<MovCajaRecibos> MovCajaRecibos {set; get; }

        public DbSet<NumeroFiscal> NumeroFiscal { set; get;}

        public DbSet<CargosVarios> CargosVarios { set; get; }

        public DbSet<Pagos> Pagos { set; get; }

        public DbSet<PagosRecibos> PagosRecibos { set; get; }

        public DbSet<DatosPagos> DatosPago { set; get; }

        public DbSet<Envios> Envios { set; get; }

        public DbSet<TarifaEnvio> TarifaEnvio { set; get; }

        public DbSet<TarifaEnvioZona> TarifaEnvioZona { set; get; }

        public DbSet<BultosEnvios> BultosEnvios { set; get; }

        public DbSet<Terminal> Terminal { set; get; }

        public DbSet<vw_cuadre_caja> vwCuadreCaja { set; get; }

        public DbSet<Secuenciales> Secuenciales { get; set; }

        public DbSet<Correspondencia> Correspondencia { set; get; }


        public DbSet<LibrasGratis> LibrasGratis { set; get; }

        public DbSet<RegistroLibrasGratis> RegistroLibrasGratis { set; get; }

        public DbSet<TarifasEspeciales> TarifasEspeciales { set; get; }

        public DbSet<TarifasEspecialesValores> TarifasEspecialesValores { set; get; }

        public DbSet<CargosSucursales> CargosSucursales { set; get; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          //  modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
           

            modelBuilder.Entity<Recibos>()
             .HasRequired(c => c.Tipos)
            .WithMany(d => d.Recibos)
            .HasForeignKey(c => c.TIPO_REC_ID);

            modelBuilder.Entity<MovCaja>()
            .HasRequired(c => c.Tipos)
           .WithMany(d => d.MovCaja)
           .HasForeignKey(c => c.TIP_MOV);

            modelBuilder.Entity<MovCaja>()
           .HasRequired(c => c.Usuarios)
          .WithMany(d => d.MovCaja)
          .HasForeignKey(c => c.COUNTER_ID);

            modelBuilder.Entity<Productos>()
                .HasRequired(c => c.Tipos)
                .WithMany(d => d.Productos)
                .HasForeignKey(c => c.PRO_TIPO_ID);


           
            try
            {
               
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }



        //modelBuilder.Entity<Product>().MapSingleType().ToTable("dfg_Product");
    }
}
