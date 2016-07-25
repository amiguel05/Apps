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
    public class vwUsuarioOpcionesRepository : GenericRepository<vw_usuario_opciones>
    {

        public vwUsuarioOpcionesRepository(AgenciasContext context)
            : base(context)
        {

        }

      
     

    }
}
