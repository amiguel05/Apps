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
    public class vwBultosValoresRepository : GenericRepository<vw_bultos_valores>
    {

        public vwBultosValoresRepository(AgenciasContext context)
            : base(context)
        {

        }

      
     

    }
}
