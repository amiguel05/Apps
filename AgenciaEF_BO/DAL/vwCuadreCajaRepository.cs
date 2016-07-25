using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaEF_BO.Models;
using AgenciaEF_BO.Models.VW;
using System.Linq.Dynamic;

namespace AgenciaEF_BO.DAL
{
    public class vwCuadreCajaRepository : GenericRepository<vw_cuadre_caja>
    {

        public vwCuadreCajaRepository(AgenciasContext context)
            : base(context)
        {

        }

      
     

    }
}
