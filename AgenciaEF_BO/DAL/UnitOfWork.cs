using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaEF_BO.Models;
using AgenciaEF_BO.Models.VW;

namespace AgenciaEF_BO.DAL
{
    public class UnitOfWork : IDisposable
    {
        private AgenciasContext context = new AgenciasContext();

        private OpcionesRepository opcionesRepository;
        private EmpresasRepository empresasRepository;
        private SucursalesRepository sucursalesRepository;
        private SuplidoresRepository suplidoresRepository;
        private OrigenRepository origenRepository;
        private GruposTiposRepository gruposTiposRepository;
        private GruposEstadosRepository gruposEstadosRepository;
        private GruposCodigosRepository gruposCodigosRepository;
        //
        private TiposRepository tiposRepository;
        private EstadosRepository estadosRepository;
        private CodigosRepository codigosRepository;
        //
        private ProductosRepository productosRepository;
        private CargosRepository cargosRepository;
        //
        private TasaCambioRepository tasaCambioRepository;
        private CargosProductoRepository cargosProductoRepository;
        private CargosValoresRepository cargosValoresRepository;
        //Seguridad
        private ModulosRepository modulosRepository;
        private UsuariosRepository usuariosRepository;
        private UsuarioSucursalRepository usuarioSucursalRepository;
        private UsuariosModulosRepository usuariosModulosRepository;
        private UsuariosOpcionesRepository usuariosOpcionesRepository;
        private RolesRepository rolesRepository;
        private RolesOpcionesRepository rolesOpcionesRepository;
        private UsuariosRolesRepository usuariosRolesRepository;

        //Atencion al cliente
        private ClientesRepository clientesRepository;
        private BultosRepository bultosRepository;
        private BultosValoresRepository bultosValoresRepository;
        private EquivalenciaBultosRepository equivalenciaBultosRepository;

        //
        private ParametrosSucursalRepository parametrosSucursalRepository;
        //

        private vwBultosValoresRepository vwBultosValoresRepository;

        private RecibosRepository recibosRepository;
        private RecibosDetRepository recibosDetRepository;

        //
        private MovCajaRepository movCajaRepository;

        private DatosPagoRepository datosPagoRepository;
        //
        private NumeroFicalRepository numeroFicalRepository;

        private CargosVariosRepository cargosVariosRepository;


        private MovCajaRecibosRepository movCajaRecibosRepository;

        private PagosRepository pagosRepository;

        private PagosRecibosRepository pagosRecibosRepository;

        private EnviosRepository enviosRepository;

        private TarifaEnvioRepository tarifaEnvioRepository;

        private TarifaEnvioZonaRepository tarifaEnvioZonaRepository;

        private BultosEnviosRepository bultosEnviosRepository;

        private TerminalRepository terminalRepository;

        //
        private vwUsuarioOpcionesRepository vwusuarioOpcionesRepository;


        private vwCuadreCajaRepository vwcuadreCajaRepository;

        private SecuencialesRepository secuencialesRepository;

        private CorrespondenciaRepository correspondenciaRepository;

        // Promociones

        private RegistroLibrasGratisRepository registroLibrasGratisRepository;

        private LibrasGratisRepository librasGratisRepository;


        private TarifasEspecialesRepository tarifasEspecialesRepository;


        private TarifasEspecialesValoresRepository tarifasEspecialesValoresRepository;

        private CargosSucursalesRepository cargosSucursalesRepository;


        public CargosSucursalesRepository CargosSucursalesRepository
        {
            get
            {

                if (this.cargosSucursalesRepository == null)
                {
                    this.cargosSucursalesRepository = new CargosSucursalesRepository(context);
                }
                return cargosSucursalesRepository;
            }
        }



        public TarifasEspecialesValoresRepository TarifasEspecialesValoresRepository
        {
            get
            {

                if (this.tarifasEspecialesValoresRepository == null)
                {
                    this.tarifasEspecialesValoresRepository = new TarifasEspecialesValoresRepository(context);
                }
                return tarifasEspecialesValoresRepository;
            }
        }


        public TarifasEspecialesRepository TarifasEspecialesRepository
        {
            get
            {

                if (this.tarifasEspecialesRepository == null)
                {
                    this.tarifasEspecialesRepository = new TarifasEspecialesRepository(context);
                }
                return tarifasEspecialesRepository;
            }
        }


        public LibrasGratisRepository LibrasGratisRepository
        {
            get
            {

                if (this.librasGratisRepository == null)
                {
                    this.librasGratisRepository = new LibrasGratisRepository(context);
                }
                return librasGratisRepository;
            }
        }

        public RegistroLibrasGratisRepository RegistroLibrasGratisRepository
        {
            get
            {

                if (this.registroLibrasGratisRepository == null)
                {
                    this.registroLibrasGratisRepository = new RegistroLibrasGratisRepository(context);
                }
                return registroLibrasGratisRepository;
            }
        }




        public CorrespondenciaRepository CorrespondenciaRepository
        {
            get
            {

                if (this.correspondenciaRepository == null)
                {
                    this.correspondenciaRepository = new CorrespondenciaRepository(context);
                }
                return correspondenciaRepository;
            }
        }


        public SecuencialesRepository SecuencialesRepository
        {
            get
            {

                if (this.secuencialesRepository == null)
                {
                    this.secuencialesRepository = new SecuencialesRepository(context);
                }
                return secuencialesRepository;
            }
        }


        public vwCuadreCajaRepository vwCuadreCajaRepository
        {
            get
            {

                if (this.vwcuadreCajaRepository == null)
                {
                    this.vwcuadreCajaRepository = new vwCuadreCajaRepository(context);
                }
                return vwcuadreCajaRepository;
            }
        }


        public vwUsuarioOpcionesRepository vwUsuarioOpcionesRepository
        {
            get
            {

                if (this.vwusuarioOpcionesRepository == null)
                {
                    this.vwusuarioOpcionesRepository = new vwUsuarioOpcionesRepository(context);
                }
                return vwusuarioOpcionesRepository;
            }
        }


        public TerminalRepository TerminalRepository
        {
            get
            {

                if (this.terminalRepository == null)
                {
                    this.terminalRepository = new TerminalRepository(context);
                }
                return terminalRepository;
            }
        }



        public BultosEnviosRepository BultosEnviosRepository
        {
            get
            {

                if (this.bultosEnviosRepository == null)
                {
                    this.bultosEnviosRepository = new BultosEnviosRepository(context);
                }
                return bultosEnviosRepository;
            }
        }


        public TarifaEnvioZonaRepository TarifaEnvioZonaRepository
        {
            get
            {

                if (this.tarifaEnvioZonaRepository == null)
                {
                    this.tarifaEnvioZonaRepository = new TarifaEnvioZonaRepository(context);
                }
                return tarifaEnvioZonaRepository;
            }
        }


        public TarifaEnvioRepository TarifaEnvioRepository
        {
            get
            {

                if (this.tarifaEnvioRepository == null)
                {
                    this.tarifaEnvioRepository = new TarifaEnvioRepository(context);
                }
                return tarifaEnvioRepository;
            }
        }


        public EnviosRepository EnviosRepository
        {
            get
            {

                if (this.enviosRepository == null)
                {
                    this.enviosRepository = new EnviosRepository(context);
                }
                return enviosRepository;
            }
        }



        public PagosRecibosRepository PagosRecibosRepository
        {
            get
            {

                if (this.pagosRecibosRepository == null)
                {
                    this.pagosRecibosRepository = new PagosRecibosRepository(context);
                }
                return pagosRecibosRepository;
            }
        }



        public PagosRepository PagosRepository
        {
            get
            {

                if (this.pagosRepository == null)
                {
                    this.pagosRepository = new PagosRepository(context);
                }
                return pagosRepository;
            }
        }



        public MovCajaRecibosRepository MovCajaRecibosRepository
        {
            get
            {

                if (this.movCajaRecibosRepository == null)
                {
                    this.movCajaRecibosRepository = new MovCajaRecibosRepository(context);
                }
                return movCajaRecibosRepository;
            }
        }


        public CargosVariosRepository CargosVariosRepository
        {
            get
            {

                if (this.cargosVariosRepository == null)
                {
                    this.cargosVariosRepository = new CargosVariosRepository(context);
                }
                return cargosVariosRepository;
            }
        }


        public NumeroFicalRepository NumeroFicalRepository
        {
            get
            {

                if (this.numeroFicalRepository == null)
                {
                    this.numeroFicalRepository = new NumeroFicalRepository(context);
                }
                return numeroFicalRepository;
            }
        }


        public DatosPagoRepository DatosPagoRepository
        {
            get
            {

                if (this.datosPagoRepository == null)
                {
                    this.datosPagoRepository = new DatosPagoRepository(context);
                }
                return datosPagoRepository;
            }
        }

        public MovCajaRepository MovCajaRepository
        {
            get
            {

                if (this.movCajaRepository == null)
                {
                    this.movCajaRepository = new MovCajaRepository(context);
                }
                return movCajaRepository;
            }
        }

       
        public RecibosRepository RecibosRepository
        {
            get
            {

                if (this.recibosRepository == null)
                {
                    this.recibosRepository = new RecibosRepository(context);
                }
                return recibosRepository;
            }
        }

        public RecibosDetRepository RecibosDetRepository
        {
            get
            {

                if (this.recibosDetRepository == null)
                {
                    this.recibosDetRepository = new RecibosDetRepository(context);
                }
                return recibosDetRepository;
            }
        }



        public vwBultosValoresRepository VW_BultosValoresRepository
        {
            get
            {

                if (this.vwBultosValoresRepository == null)
                {
                    this.vwBultosValoresRepository = new vwBultosValoresRepository(context);
                }
                return vwBultosValoresRepository;
            }
        }




        #region "Precios"

        public CargosValoresRepository CargosValoresRepository
        {
            get
            {

                if (this.cargosValoresRepository == null)
                {
                    this.cargosValoresRepository = new CargosValoresRepository(context);
                }
                return cargosValoresRepository;
            }
        }

        public CargosProductoRepository CargosProductoRepository
        {
            get
            {

                if (this.cargosProductoRepository == null)
                {
                    this.cargosProductoRepository = new CargosProductoRepository(context);
                }
                return cargosProductoRepository;
            }
        }


        public TasaCambioRepository TasaCambioRepository
        {
            get
            {

                if (this.tasaCambioRepository == null)
                {
                    this.tasaCambioRepository = new TasaCambioRepository(context);
                }
                return tasaCambioRepository;
            }
        }

        public CargosRepository CargosRepository
        {
            get
            {

                if (this.cargosRepository == null)
                {
                    this.cargosRepository = new CargosRepository(context);
                }
                return cargosRepository;
            }
        }

        public ProductosRepository ProductosRepository
        {
            get
            {

                if (this.productosRepository == null)
                {
                    this.productosRepository = new ProductosRepository(context);
                }
                return productosRepository;
            }
        }

        #endregion

        #region "Parametros"

        public ParametrosSucursalRepository ParametrosSucursalRepository
        {
            get
            {
                if (this.parametrosSucursalRepository == null)
                    this.parametrosSucursalRepository = new ParametrosSucursalRepository(context);

                return this.parametrosSucursalRepository;
            }
        }


        public TiposRepository TiposRepository
        {
            get
            {
                if (this.tiposRepository == null)
                    this.tiposRepository = new TiposRepository(context);

                return this.tiposRepository;
            }
        }


        public GruposTiposRepository  GruposTiposRepository
        {
            get
            {
                if (this.gruposTiposRepository == null)
                    this.gruposTiposRepository = new GruposTiposRepository(context);

                return this.gruposTiposRepository;
            }
        }

        public CodigosRepository CodigosRepository
        {
            get
            {
                if (this.codigosRepository == null)
                    this.codigosRepository = new CodigosRepository(context);

                return this.codigosRepository;
            }
        }

        public GruposCodigosRepository GruposCodigosRepository
        {
            get
            {
                if (this.gruposCodigosRepository == null)
                    this.gruposCodigosRepository = new GruposCodigosRepository(context);

                return this.gruposCodigosRepository;
            }
        }

        public EstadosRepository EstadosRepository
        {
            get
            {
                if (this.estadosRepository == null)
                    this.estadosRepository = new EstadosRepository(context);

                return this.estadosRepository;
            }
        }

        public GruposEstadosRepository GruposEstadosRepository
        {
            get
            {
                if (this.gruposEstadosRepository == null)
                    this.gruposEstadosRepository = new GruposEstadosRepository(context);

                return this.gruposEstadosRepository;
            }
        }

        //private GenericRepository<Course> courseRepository;


        public  OrigenRepository OrigenRepository
        {
            get
            {
                if (this.origenRepository  ==null)
                {
                    this.origenRepository = new OrigenRepository(context);
                }
                return origenRepository;
            }
        }

        public SuplidoresRepository SuplidoresRepository
        {
            get
            {

                if (this.suplidoresRepository == null)
                {
                    this.suplidoresRepository = new SuplidoresRepository(context);
                }
                return suplidoresRepository;
            }
        }

        #endregion

        #region "Seguridad"

        public UsuariosRolesRepository UsuariosRolesRepository
        {
            get
            {

                if (this.usuariosRolesRepository == null)
                {
                    this.usuariosRolesRepository = new UsuariosRolesRepository(context);
                }
                return usuariosRolesRepository;
            }
        }

        public RolesOpcionesRepository RolesOpcionesRepository
        {
            get
            {

                if (this.rolesOpcionesRepository == null)
                {
                    this.rolesOpcionesRepository = new RolesOpcionesRepository(context);
                }
                return rolesOpcionesRepository;
            }
        }

        public RolesRepository RolesRepository
        {
            get
            {

                if (this.rolesRepository == null)
                {
                    this.rolesRepository = new RolesRepository(context);
                }
                return rolesRepository;
            }
        }

        public UsuariosModulosRepository UsuariosModulosRepository
        {
            get
            {

                if (this.usuariosModulosRepository == null)
                {
                    this.usuariosModulosRepository = new UsuariosModulosRepository(context);
                }
                return usuariosModulosRepository;
            }
        }


        public UsuariosOpcionesRepository UsuariosOpcionesRepository
        {
            get
            {

                if (this.usuariosOpcionesRepository == null)
                {
                    this.usuariosOpcionesRepository = new UsuariosOpcionesRepository(context);
                }
                return usuariosOpcionesRepository;
            }
        }



        public UsuarioSucursalRepository UsuarioSucursalRepository
        {
            get
            {

                if (this.usuarioSucursalRepository == null)
                {
                    this.usuarioSucursalRepository = new UsuarioSucursalRepository(context);
                }
                return usuarioSucursalRepository;
            }
        }



        public UsuariosRepository UsuariosRepository
        {
            get
            {

                if (this.usuariosRepository == null)
                {
                    this.usuariosRepository = new UsuariosRepository(context);
                }
                return usuariosRepository;
            }
        }

        public ModulosRepository ModulosRepository
        {
            get
            {

                if (this.modulosRepository == null)
                {
                    this.modulosRepository = new ModulosRepository(context);
                }
                return modulosRepository;
            }
        }
        
        public OpcionesRepository OpcionesRepository
        {
            get
            {

                if (this.opcionesRepository == null)
                {
                    this.opcionesRepository = new OpcionesRepository(context);
                }
                return opcionesRepository;
            }
        }

        #endregion


        public EquivalenciaBultosRepository EquivalenciaBultosRepository
        {
            get
            {

                if (this.equivalenciaBultosRepository == null)
                {
                    this.equivalenciaBultosRepository = new EquivalenciaBultosRepository(context);
                }
                return equivalenciaBultosRepository;
            }
        }


        public BultosValoresRepository BultosValoresRepository
        {
            get
            {

                if (this.bultosValoresRepository == null)
                {
                    this.bultosValoresRepository = new BultosValoresRepository(context);
                }
                return bultosValoresRepository;
            }
        }

        public BultosRepository BultosRepository
        {
            get
            {

                if (this.bultosRepository == null)
                {
                    this.bultosRepository = new BultosRepository(context);
                }
                return bultosRepository;
            }
        }


        public ClientesRepository ClientesRepository
        {
            get
            {

                if (this.clientesRepository == null)
                {
                    this.clientesRepository = new ClientesRepository(context);
                }
                return clientesRepository;
            }
        }


        public EmpresasRepository EmpresasRepository
        {
            get
            {

                if (this.empresasRepository == null)
                {
                    this.empresasRepository = new EmpresasRepository(context);
                }
                return empresasRepository;
            }
        }

        public SucursalesRepository SucursalesRepository
        {
            get
            {

                if (this.sucursalesRepository == null)
                {
                    this.sucursalesRepository = new SucursalesRepository(context);
                }
                return sucursalesRepository;
            }
        }
    

        public void Save()
        {
            context.SaveChanges();     
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}
