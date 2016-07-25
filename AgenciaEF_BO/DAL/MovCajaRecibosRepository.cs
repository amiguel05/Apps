using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaEF_BO.Models;
using System.Linq.Dynamic;

namespace AgenciaEF_BO.DAL
{
    public class MovCajaRecibosRepository : GenericRepository<MovCajaRecibos>
    {

        public MovCajaRecibosRepository(AgenciasContext context)
            : base(context)
        {

        }


    }
}
