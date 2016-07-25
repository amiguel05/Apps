using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaEF_BO.Models;
using System.Linq.Dynamic;

namespace AgenciaEF_BO.DAL
{
    public class NumeroFicalRepository : GenericRepository<NumeroFiscal>
    {

        public NumeroFicalRepository(AgenciasContext context)
            : base(context)
        {

        }

  
    }
}
