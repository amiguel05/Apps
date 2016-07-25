using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaEF_BO.Models;
using AgenciaEF_BO.DAL;

namespace AgenciaEF_BO.DAL
{
    public class OpcionesRepository : GenericRepository<Opciones>
    {

        public OpcionesRepository(AgenciasContext context)
            : base(context)
        {

        }




    }
}
