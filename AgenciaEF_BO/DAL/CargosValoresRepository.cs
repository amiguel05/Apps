using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaEF_BO.Models;

namespace AgenciaEF_BO.DAL
{
    public class CargosValoresRepository : GenericRepository<CargosValores>
    {

        public CargosValoresRepository(AgenciasContext context)
            : base(context)
        {

        }

      


    }
}
