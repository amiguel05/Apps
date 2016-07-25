using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaEF_BO.Models;
using System.Linq.Dynamic;

namespace AgenciaEF_BO.DAL
{
    public class MovCajaRepository : GenericRepository<MovCaja>
    {

        public MovCajaRepository(AgenciasContext context)
            : base(context)
        {

        }


    }
}
